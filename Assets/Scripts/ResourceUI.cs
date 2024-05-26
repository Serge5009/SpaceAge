using UnityEngine;
using TMPro;

public class ResourceUI : MonoBehaviour
{
    public PlanetEconomy linkedPlanet;
    public bool isReserve;                     //  TRUE = reserve, FALSE = local
    public RES resType;

    long amount;

    [SerializeField] TextMeshProUGUI valueInUI;

    void Update()
    {
        if (isReserve)
            amount = linkedPlanet.planetReserves[(int)resType];
        else
            amount = linkedPlanet.localResources[(int)resType];

        valueInUI.text = amount.ToString("F0");
    }
}
