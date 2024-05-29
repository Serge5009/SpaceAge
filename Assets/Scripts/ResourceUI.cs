using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public PlanetEconomy linkedPlanet;
    public bool isComposition;                     //  TRUE = composition, FALSE = local
    public RES resType;

    double amount;

    [SerializeField] TextMeshProUGUI valueInUI;

    void Update()
    {
        if (isComposition)
            amount = (long)linkedPlanet.planetComposition[(int)resType];
        else
            amount = linkedPlanet.localResources[(int)resType];

        if (isComposition)
            valueInUI.text = amount.ToString("F2") + "%";
        else
            valueInUI.text = amount.ToString("F0");

    }
}
