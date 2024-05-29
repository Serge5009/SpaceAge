using UnityEngine;

public class Building : MonoBehaviour
{
    public PlanetEconomy linkedEconomy;

    public BuildingData buildingData;

    public int numberBuilt;

    public void Tick()
    {
        //  Calculating the amount of resources to add
        linkedEconomy.localResources[(int)buildingData.generatedResource] += buildingData.generationRate * numberBuilt * linkedEconomy.planetComposition[(int)buildingData.generatedResource] / 100;
    }
}
