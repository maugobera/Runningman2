using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileAccelerometer : MonoBehaviour
{
    public float speed = 10f;
    public Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = -Input.acceleration.y;
        direction.z = Input.acceleration.x;
        if (direction.sqrMagnitude>1)
        {
            direction.Normalize();
        }
    }

}
