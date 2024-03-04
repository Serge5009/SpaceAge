using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public string planetName;

    public long population;

    public float radius;



    void Start()
    {
        transform.localScale = new Vector3(radius / 1000, radius / 1000, radius / 1000);
    }

    void Update()
    {
        
    }
}
