using UnityEngine;
using TMPro;

public class BuildingUILine : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buildingName;

    public PlanetEconomy linkedEconomy;
    public int amountBuilt;

    public BuildingData bData;

    void Start()
    {
    }

    public void UpdateBuildingUI()
    {
        buildingName.text = bData.buildingName;
    }

    public void OnBuildClick()
    {
        linkedEconomy.TryToBuild(bData);
    }
}
