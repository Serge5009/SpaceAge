using System.Collections;
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

    public GameObject focusOn;  //  Space body the camera and UI should focus on
    public UIManager UImanager;

    [SerializeField] GameObject camObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GoBack()
    {
        GameObject parentPlanet = focusOn.GetComponent<Planet>().orbitAround;
        if (parentPlanet)
            FocusOnNew(parentPlanet);

        camObject.GetComponent<CameraController>().UpdateCamera();
    }

    public void FocusOnNew(GameObject newFocus)
    {
        focusOn = newFocus;
        UImanager.UpdateUI();
    }

    void LateUpdate()
    {
        camObject.transform.position = focusOn.transform.position;
    }
}
