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
    public float orbitRadius;
    public float orbitalVelocity;

    void Start()
    {
        transform.localScale = new Vector3(radius / 1000, radius / 1000, radius / 1000);
        //if(orbitAround)
        //{
        //    transform.localPosition = orbitAround.transform.position + new Vector3(orbitRadius / 10000, 0 ,0);  //  Orbit distance in the game is 10 times less than real life
        //}
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
            transform.localPosition = new Vector3(orbitRadius / 10000, 0, 0);  //  Orbit distance in the game is 10 times less than real life
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