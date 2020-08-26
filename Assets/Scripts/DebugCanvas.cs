using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugCanvas : MonoBehaviour
{
    public MobileAccelerometer mobileAccelerometer;
    public Text text;
  

    // Update is called once per frame
    void Update()
    {
        text.text = mobileAccelerometer.direction.ToString();  
    }
}
