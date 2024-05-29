using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Economy/Building")]
public class BuildingData : ScriptableObject
{
    public string buildingName;
    public BUILDING buildingID;

    public Sprite icon;

    public RES generatedResource;
    public float generationRate;



}
