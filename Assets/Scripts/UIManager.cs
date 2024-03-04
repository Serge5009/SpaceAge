using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    GameObject focusOn;

    [SerializeField] TextMeshProUGUI focusNameField;
    [SerializeField] TMP_Dropdown forwardSelector;

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

    public void UpdateUI()
    {
        //  Update data
        focusOn = GameManager.gameManager.focusOn;

        //  Update name
        focusNameField.text = focusOn.GetComponent<Planet>().planetName;

        //  Update forward options
        forwardSelector.ClearOptions();
        List<GameObject> childOrbits = focusOn.GetComponent<Planet>().orbits;
        List<TMP_Dropdown.OptionData> optionsToAdd = new();
        foreach(GameObject chOrbit in childOrbits)
        {
            TMP_Dropdown.OptionData optionData = new(chOrbit.GetComponent<Planet>().planetName);
            optionsToAdd.Add(optionData);
        }
        forwardSelector.AddOptions(optionsToAdd);

    }
}
