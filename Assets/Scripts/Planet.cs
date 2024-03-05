using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName;
    public BodyClass bodyClass;

    public long population;

    public float radius;    //  In KM
    public decimal volume;      //  In 1kk KM^3
    public decimal mass;        //  In 1kkk T
    [HideInInspector] public float gAcc;

    public GameObject orbitAround;
    Planet parentPlanet;
    public float orbitRadius;
    public float orbitalVelocity;

    public List<GameObject> orbits;

    [SerializeField] float density = 5;     //  In g/cm^3

    void Start()
    {
        float ingameScale = radius / 1000;  //  1 unit = 1000km
        if (bodyClass == BodyClass.STAR)
            ingameScale /= 2;               //  Cut star radius in half

        transform.localScale = new Vector3(ingameScale, ingameScale, ingameScale);

        if(orbitAround)
        {
            parentPlanet = orbitAround.GetComponent<Planet>();  //  Added itself to parent's children if needed
            if (!parentPlanet.orbits.Contains(gameObject))  
                parentPlanet.orbits.Add(gameObject);
        }


        RecalculateStats();
    }

    void RecalculateStats()
    {
        volume = (decimal)Mathf.Pow(radius, 3) * (decimal)4.1888 / (decimal)1000000 ;   //  V = 4.1888 r^3
        mass = volume * (decimal)density * 1000000;                                     //  m = V * (converted density)
        gAcc = (float)(mass / (decimal)Mathf.Pow(radius, 2) * (decimal)6.674) / 100000;          //  6.674 * 10^-11 * m * 10^12 (we store it in 1kkk T) / r^2

        Debug.Log(planetName + "\tpop:\t" + population + "\nr = " + radius + "\tV = " + volume + "\nm = " + mass + "\tg = " + gAcc);
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        if (orbitAround)
        {
            HandleOrbit();
        }
    }



    GameObject orbitAnchor;
    void HandleOrbit()
    {
        if(!orbitAnchor)
        {
            orbitAnchor = Instantiate(new GameObject(), orbitAround.transform.position, Quaternion.identity);
            orbitAnchor.name = planetName + " container";
            this.transform.parent = orbitAnchor.transform;

            //  Calculate orbit     //  Real distance between planets is insane, so we'll have to reduce it
            float inGameDistance = orbitRadius / 500000;    //  Our planets are 500 times closer to each other than in real life
            inGameDistance += orbitAround.GetComponent<Planet>().radius / 1900;
            if (bodyClass == BodyClass.SATTELITE)
                inGameDistance *= 2;
            transform.localPosition = new Vector3(inGameDistance, 0, 0);

            //  Random orbit position
            orbitAnchor.transform.Rotate(0, Random.Range(0, 360f), 0);
        }
        else
        {
            orbitAnchor.transform.position = orbitAround.transform.position;
            orbitAnchor.transform.Rotate(0, -orbitalVelocity * Time.fixedDeltaTime, 0);
        }
    }



}

public enum BodyClass
{
    STAR,
    PLANET,
    SATTELITE,
    SPACE_STATION,

    NUM_BODY_CLASSES
}