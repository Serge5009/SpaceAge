using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Economy/Building")]
public class BuildingData : ScriptableObject
{
    public BUILDING buildingID;

    public string buildingName;
    public Sprite icon;

    public BUILD_TYPE buildingType;
    public RES generatedResource;
    public RES consumedResource;
    public float productionRate;
    public float consumptionRate;

}
