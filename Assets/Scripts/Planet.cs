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
        transform.localScale = new Vector3(radius / 1000, radius / 1000, radius / 1000);

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
            float inGameDistance = orbitRadius / 200000;    //  Our planets are 200 times closer to each other than in real life

            inGameDistance += orbitAround.GetComponent<Planet>().radius / 1000;


                transform.localPosition = new Vector3(inGameDistance, 0, 0);
        }
        else
        {
            orbitAnchor.transform.position = orbitAround.transform.position;
            orbitAnchor.transform.Rotate(0, orbitalVelocity * Time.fixedDeltaTime, 0);
        }
    }



}

public enum BodyClass
{
    STAR,
    PLANET,
    SATTELITE,

    NUM_BODY_CLASSES
}