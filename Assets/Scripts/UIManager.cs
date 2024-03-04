using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI focusNameField;
    GameObject focusOn;

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
        focusOn = GameManager.gameManager.focusOn;
        focusNameField.text = focusOn.GetComponent<Planet>().planetName;
    }
}
