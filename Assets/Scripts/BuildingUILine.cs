using UnityEngine;
using TMPro;

public class BuildingUILine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buildingName;

    public PlanetEconomy linkedEconomy;
    public Building linkedBuilding;
    public int numberBuilt;

    public BuildingData bData;

    void Start()
    {
        FetchFromLocalEconomy();
    }

    float timedUpdateTimer = 0.0f;
    private void Update()
    {
        if(!linkedBuilding)
        {
            numberBuilt = 0;
            return;
        }

        numberBuilt = linkedBuilding.numberBuilt;

        timedUpdateTimer += Time.deltaTime;
        if(timedUpdateTimer >= 1)
        {
            timedUpdateTimer = 0;
            UpdateBuildingUI();
        }
    }

    public void UpdateBuildingUI()
    {
        buildingName.text = numberBuilt + " x " + bData.buildingName;
    }

    public void OnBuildClick()
    {
        linkedEconomy.TryToBuild(bData);
        FetchFromLocalEconomy();
        UpdateBuildingUI();
    }

    void FetchFromLocalEconomy()    //  This function ties the UI element to a building in local economy when needed
    {
        if (linkedBuilding)
            return;

        foreach (Building i in linkedEconomy.buildings)
        {
            if(i.buildingData.buildingID == bData.buildingID)
            {
                linkedBuilding = i;
                return;
            }
        }
    }
}
