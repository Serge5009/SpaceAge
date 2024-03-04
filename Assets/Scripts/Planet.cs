using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName;

    public long population;

    public float radius;

    public GameObject orbitAround;
    public float orbitRadius;
    public float orbitalVelocity;

    void Start()
    {
        transform.localScale = new Vector3(radius / 1000, radius / 1000, radius / 1000);
        if(orbitAround)
        {
            transform.localPosition = orbitAround.transform.position + new Vector3(orbitRadius / 10000, 0 ,0);  //  Orbit distance in the game is 10 times less than real life
        }
    }

    void Update()
    {
        
    }
}
