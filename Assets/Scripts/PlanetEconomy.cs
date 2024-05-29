using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEconomy : MonoBehaviour
{
    public long population;

    public List<float> planetComposition;
    public List<long> localResources;

    float tickSpeed;
    float tickTimer;

    void Start()
    {
        RebalanceComposition();
        tickSpeed = GameManager.gameManager.tickSpeed;  //  Fetching the tick speed
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

    void BuildingsTick()
    {

    }
}

