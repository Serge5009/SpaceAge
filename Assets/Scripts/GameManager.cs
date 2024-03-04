using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject focusOn;  //  Space body the camera and UI should focus on


    [SerializeField] GameObject camObject;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void LateUpdate()
    {
        camObject.transform.position = focusOn.transform.position;
    }
}
