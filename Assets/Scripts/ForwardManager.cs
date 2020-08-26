using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardManager : MonoBehaviour
{
    public static ForwardManager instance;
    public Vector3 forwardPoint;
    public Camera aRCamera;
    public float range;
    public GameObject testForward;

    void Awake()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(aRCamera.transform.localPosition.x, aRCamera.transform.localPosition.y, aRCamera.transform.localPosition.z + range);
        forwardPoint = temp;
        //testForward.transform.position = forwardPoint;
    }
}
