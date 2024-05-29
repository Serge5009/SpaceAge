using UnityEngine;

public class Building : MonoBehaviour
{
    public PlanetEconomy linkedEconomy;

    public BuildingData buildingData;



    public int numberBuilt;

    public BUILD_TYPE buildingType;
    public RES generatedResource;
    public RES consumedResource;
    public float productionRate;

    void Start()
    {
        buildingType = buildingData.buildingType;
        generatedResource = buildingData.generatedResource;
        consumedResource = buildingData.consumedResource;
        productionRate = buildingData.productionRate;
    }

    public void Tick()
    {
        switch (buildingType)
        {
            case BUILD_TYPE.HARVESTER:
                //  Calculating the amount of resources to add
                linkedEconomy.localResources[(int)generatedResource] += productionRate * numberBuilt * linkedEconomy.planetComposition[(int)generatedResource] / 100;
                break;

            case BUILD_TYPE.REFINERY:
                bool canDoTick = true;
                if (linkedEconomy.localResources[(int)consumedResource] < productionRate)
                    canDoTick = false;

                if(canDoTick)
                {
                    linkedEconomy.localResources[(int)generatedResource] += productionRate * numberBuilt;
                    linkedEconomy.localResources[(int)consumedResource] -= productionRate * numberBuilt;
                }

                break;

            default:
                break;
        }

    }
}
