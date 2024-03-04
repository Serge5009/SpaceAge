using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0, 1.0f)]
    public float sensitivity;


    //  Input tracking
    Vector3 touchStart;
    Vector3 touchStartLocal;
    Vector3 lastFramePosition;


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
            //  Zoom code from the other project

            //Touch t0 = Input.GetTouch(0);
            //Touch t1 = Input.GetTouch(1);

            //Vector2 t0OldPos = t0.position - t0.deltaPosition;
            //Vector2 t1OldPos = t1.position - t1.deltaPosition;

            //float newDist = Vector2.Distance(t0.position, t1.position);
            //float oldDist = Vector2.Distance(t0OldPos, t1OldPos);

            //float difference = newDist - oldDist;

            //Zoom(difference * zoomSens);
        }
        else if (Input.GetMouseButton(0) && lastFramePosition != null)        //  While finger is down - move relatively to the start position
        {
            Vector3 screenMove = Input.mousePosition - lastFramePosition;
            screenMove *= sensitivity;
            transform.Rotate(-screenMove.y, screenMove.x, -transform.rotation.eulerAngles.z);

            //Debug.Log(camMoveDirection);
        }

        lastFramePosition = Input.mousePosition;
    }


}
