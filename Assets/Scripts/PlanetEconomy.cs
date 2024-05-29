using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEconomy : MonoBehaviour
{
    public long population;

    public List<float> planetComposition;
    public List<double> localResources;

    public List<int> buildings;

    float tickSpeed;
    float tickTimer;

    void Start()
    {
        tickSpeed = GameManager.gameManager.tickSpeed;  //  Fetching the tick speed

        RebalanceComposition(); 
        GenerateBuildingsList();
    }

    void Update()
    {

        //  Tick timer
        tickTimer += Time.deltaTime;
        if(tickTimer >= tickSpeed)
        {
            tickTimer -= tickSpeed;
            BuildingsTick();
        }
        if (tickTimer > 1)
            Debug.LogWarning(gameObject + " - Economy tick is " + tickTimer.ToString("F2") + "s behind!");
    }

    void RebalanceComposition()
    {
        float currentSum = 0.0f;

        foreach (float i in planetComposition)
        {
            currentSum += i;
        }

        if(currentSum <= 0)
        {
            Debug.LogWarning("No weights for planet resources " + this);
            return;
        }

        currentSum /= 100;
        for (int i = 0; i < planetComposition.Count; i++)
        {
            planetComposition[i] /= currentSum;
        }
    }

    void GenerateBuildingsList()
    {
        //  TO DO:  change to loading from save

        //  For now just creates an empty list

        buildings = new();
        for (int i = 0; i < (int)BUILDING.NUM_BUILDINGS; i++)
        {
            buildings.Add(0);
        }
    }

    void BuildingsTick()
    {
        if(buildings[(int)BUILDING.HARV_GAS] > 0)
        {
            localResources[(int)RES.GASSES] += 5 * buildings[(int)BUILDING.HARV_GAS] * planetComposition[(int)RES.GASSES] / 100;
        }
        if(buildings[(int)BUILDING.HARV_WATER] > 0)
        {
            localResources[(int)RES.WATER] += 5 * buildings[(int)BUILDING.HARV_WATER] * planetComposition[(int)RES.WATER] / 100;
        }
    }
}

