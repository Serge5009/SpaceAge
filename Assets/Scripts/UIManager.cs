using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameObject focusOn;

    [SerializeField] TMP_Dropdown forwardSelector;
    [SerializeField] GameObject infoPanel;

    void Start()
    {
        UpdateUI();
    }

    void Update()
    {
        
    }

    public void GoBack()
    {
        GameManager.gameManager.GoBack();
    }

    public void GoFwd()
    {
        int childIndex = forwardSelector.value - 1;

        if (childIndex < 0)
            return;
        GameManager.gameManager.FocusOnNew(focusOn.GetComponent<Planet>().orbits[childIndex]);
    }

    public void SpawnInfo()
    {
        GameObject spawnedPanel = Instantiate(infoPanel, transform);
    }

    public void UpdateUI()
    {
        //  Update data
        focusOn = GameManager.gameManager.focusOn;

        //  Update forward options
        forwardSelector.ClearOptions();
        List<GameObject> childOrbits = focusOn.GetComponent<Planet>().orbits;
        List<TMP_Dropdown.OptionData> optionsToAdd = new();

            //  Add this planet
        TMP_Dropdown.OptionData firstOptionData = new(focusOn.GetComponent<Planet>().planetName);
        optionsToAdd.Add(firstOptionData);

            //  Add children
        foreach (GameObject chOrbit in childOrbits)
        {
            TMP_Dropdown.OptionData optionData = new(chOrbit.GetComponent<Planet>().planetName);
            optionsToAdd.Add(optionData);
        }
        forwardSelector.AddOptions(optionsToAdd);

    }
}
