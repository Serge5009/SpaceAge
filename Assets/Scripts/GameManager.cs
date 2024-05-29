using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager gameManager   //  Singleton for Game Manager
    {
        get
        {
            _instance = GameObject.FindObjectOfType<GameManager>();
            if (_instance == null)
            {
                Debug.LogError("No Game Manager found!");
            }
            //DontDestroyOnLoad(_instance.gameObject);
            return _instance;
        }
    }
    public float tickSpeed = 0.1f;

    public GameObject focusOn;  //  Space body the camera and UI should focus on
    public GameObject localStar;
    public GameObject dirLight;

    public UIManager UImanager;

    [SerializeField] GameObject camObject;

    public List<string> resourceNames;
    public List<Sprite> resourceIcon;
    public List<BuildingData> allBuildings;

    void Start()
    {
        FocusOnNew(focusOn);
    }

    void Update()
    {
        if (focusOn == localStar)
        {
            dirLight.transform.rotation = camObject.transform.rotation;
        }
        else
        {
            dirLight.transform.position = localStar.transform.position;
            dirLight.transform.LookAt(focusOn.transform.position); 
        }

    }

    public void GoBack()
    {
        GameObject parentPlanet = focusOn.GetComponent<Planet>().orbitAround;
        if (parentPlanet)
            FocusOnNew(parentPlanet);
    }

    public void FocusOnNew(GameObject newFocus)
    {
        focusOn = newFocus;
        UImanager.UpdateUI();
        camObject.GetComponent<CameraController>().UpdateCamera();
    }

}


public enum RES
{
    //  Basic
    GASSES,
    WATER,
    METALS,
    CARBON,
    PRECIOUS,
    RADIOACTIVE,

    //  Refined
    ALLOYS,

    NUM_RES
}

public enum BUILDING
{
    HARV_GAS,
    HARV_WATER,
    HARV_METAL,
    HARV_CARBON,
    HARV_PRECIOUS,
    HARV_RADIOACTIVE,

    REF_ALLOY,
    

    NUM_BUILDINGS
}

public enum BUILD_TYPE
{
    HARVESTER,      //  Produces basic resources based on planet composition
    REFINERY,       //  Uses resources to produce other resources

    NUM_BUILD_TYPE
}
