using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDirection : MonoBehaviour
{
    public float followRate = 1f;
    private GameObject followingGameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ARTapToPlace.instance.spawnedObject)
        {
            followingGameObject = ARTapToPlace.instance.spawnedObject;
            Vector3 positionTarget = ForwardManager.instance.forwardPoint;
            followingGameObject.transform.position = Vector3.Lerp(followingGameObject.transform.position, positionTarget, Time.deltaTime * followRate);
        }
    }
}
