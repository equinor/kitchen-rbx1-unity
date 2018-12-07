using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointCommandUI : MonoBehaviour {

    public GameObject[] joints;

    private float shoulderSlider = 0.0f;

    void OnGUI()
    {
        shoulderSlider = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), shoulderSlider, 0.0f, 10.0f);

        if (GUI.Button(new Rect(25, 55, 100, 30), "Apply"))
        {
            joints[0].transform.Rotate(100 * Time.deltaTime, 0, 0);
            
        }
    }
}

