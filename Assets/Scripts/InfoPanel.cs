using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameField;
    [SerializeField] TextMeshProUGUI typeField;
    [SerializeField] TextMeshProUGUI radField;
    [SerializeField] TextMeshProUGUI oRadField;
    [SerializeField] TextMeshProUGUI massField;
    [SerializeField] TextMeshProUGUI volField;
    [SerializeField] TextMeshProUGUI gField;
    [SerializeField] TextMeshProUGUI densField;

    Planet currentPlanet;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetMouseButtonUp(0))
            Destroy(gameObject);
    }

    public void UpdateInfo(GameObject infoObject)
    {
        currentPlanet = infoObject.GetComponent<Planet>();
        nameField.text = currentPlanet.planetName;
        string typeText = "Error";
        if (currentPlanet.bodyClass == BodyClass.PLANET)
            typeText = "Planet in " + currentPlanet.orbitAround.GetComponent<Planet>().planetName + " system";
        else if (currentPlanet.bodyClass == BodyClass.SATTELITE)
            typeText = "Moon of " + currentPlanet.orbitAround.GetComponent<Planet>().planetName;
        else if (currentPlanet.bodyClass == BodyClass.SPACE_STATION)
            typeText = "Station on " + currentPlanet.orbitAround.GetComponent<Planet>().planetName + " orbit";
        if (currentPlanet.bodyClass == BodyClass.STAR)
            typeText = "Star";
        typeField.text = typeText;

    }
}
