using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject focusOn;


    [Range(0, 1.0f)]
    public float sensitivity;
    [Range(0, 1.0f)]
    public float zoomSensitivity;

    public float zoomLevel = 3.0f;
    [SerializeField] Vector3 baseCameraPosition;

    //  Input tracking
    //Vector3 touchStart;
    //Vector3 touchStartLocal;
    Vector3 lastFramePosition;

    //  Settings
    public float zoomSens = 0.5f;

    //  Camera data
    [SerializeField] float locationLerp;
    [SerializeField] float zoomLerp;
    [SerializeField] float rotationLerp;
    Vector3 targetLocation;
    bool lerpForLocation = false;
    float locationLerpTimer;
    float targetZoom;
    Quaternion targetRotation;

    void Start()
    {
        
    }

    void Update()
    {


        if (Input.GetMouseButtonDown(0))    //  Remember the tocuh position every time player touches the screen
        {

            //Debug.Log("Started touch at: " + screenTouchPosition);
        }
        if (Input.touchCount == 2)
        {
            //  Zoom code from an old project   (transportation game)
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            Vector2 t0OldPos = t0.position - t0.deltaPosition;
            Vector2 t1OldPos = t1.position - t1.deltaPosition;

            float newDist = Vector2.Distance(t0.position, t1.position);
            float oldDist = Vector2.Distance(t0OldPos, t1OldPos);

            float difference = newDist - oldDist;

            targetZoom -= difference * zoomSens;
        }
        else if (Input.GetMouseButton(0) && lastFramePosition != Vector3.zero)        //  While finger is down - move relatively to the start position
        {
            Vector3 screenMove = Input.mousePosition - lastFramePosition;
            screenMove *= sensitivity;
            transform.Rotate(-screenMove.y, screenMove.x, -transform.rotation.eulerAngles.z);

            //Debug.Log(camMoveDirection);
        }

        lastFramePosition = Input.mousePosition;
        if(!Input.GetMouseButton(0))
            lastFramePosition = Vector3.zero;
    }

    private void LateUpdate()
    {
        //  Location lerp
        targetLocation = focusOn.transform.position;

        if (lerpForLocation)
            transform.position = Vector3.Lerp(transform.position, targetLocation, locationLerp * Time.deltaTime);
        else
            transform.position = targetLocation;
        locationLerpTimer -= Time.deltaTime;
        if (locationLerpTimer <= 0.0f)
            lerpForLocation = false;

        //  Zoom lerp
        zoomLevel = Mathf.Lerp(zoomLevel, targetZoom, zoomLerp * Time.deltaTime);
        transform.GetChild(0).localPosition = baseCameraPosition * zoomLevel;
    }

    void StartLocationLerp()
    {
        locationLerpTimer = 2.5f / locationLerp;
        lerpForLocation = true;
    }

    public void UpdateCamera()
    {
        //  Update data
        focusOn = GameManager.gameManager.focusOn;

        StartLocationLerp();

        targetZoom = focusOn.GetComponent<Planet>().radius / 2000;
    }
}
