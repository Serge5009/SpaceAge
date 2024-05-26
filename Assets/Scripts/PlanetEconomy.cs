using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEconomy : MonoBehaviour
{
    public long population;

    public List<long> planetReserves;
    public List<long> localResources;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

public enum RES
{
    GASSES,
    WATER,
    METALS,
    CARBON,
    PRECIOUS,
    RADIOACTIVE,

    NUM_RES
}
