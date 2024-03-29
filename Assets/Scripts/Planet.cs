using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName;
    public BodyClass bodyClass;

    public long population;

    public float radius;

    public GameObject orbitAround;
    Planet parentPlanet;
    public float orbitRadius;
    public float orbitalVelocity;

    public List<GameObject> orbits;

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