using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;

public class ARTapToPlace : MonoBehaviour
{
    public static ARTapToPlace instance;
    public GameObject objectToPlace;
    private ARRaycastManager arRaycastManager;
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private Vector2 touchPosition;
    //public Button StartButton;
    //public GameObject StartPanel;
    private ARSessionOrigin aRSessionOrigin;
    public Camera aRCamera;
    public GameObject spawnedObject;
    public MobileAccelerometer mobileAccelerometer;

    //public void Dismiss() => StartPanel.SetActive(false);


    void Awake()
    {
        instance = this;
        arRaycastManager = GetComponent<ARRaycastManager>();
        aRSessionOrigin = GetComponent<ARSessionOrigin>();
        //StartButton.onClick.AddListener(Dismiss);

    }
    // if we have touched our screen and where
    bool TryGetTouchPosition(out Vector2 touchPosition)  // = either true or false
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;    // a default value for a Vector2 (0,0)
        return false;
    }
    
    void Update()
    {
        // first have to detect if we've touched the screen
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(spawnedObject == null)

            {
                spawnedObject = Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                //spawnedObject.transform.SetParent(aRCamera.transform);
            }
            else
            {
                return;
            }
        }
        if (spawnedObject != null)
        {
            spawnedObject.transform.forward = mobileAccelerometer.direction;
        }
    }
}