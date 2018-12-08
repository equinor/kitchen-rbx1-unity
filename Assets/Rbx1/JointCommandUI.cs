using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointCommandUI : MonoBehaviour
{

    public GameObject[] joints;

    private float shoulderSlider = 0.0f;

    void OnGUI()
    {
        shoulderSlider = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), shoulderSlider, -1.0f, 1.0f);

        if (GUI.Button(new Rect(25, 55, 100, 30), "Apply"))
        {
            //var j = joints[0];
            //var x = j.transform.eulerAngles.x;
            //var z = j.transform.eulerAngles.z;
            //var y = j.transform.eulerAngles.y;
            //Vector3 desiredRot = new Vector3(x, y + (shoulderSlider * 360), z);

            //j.transform.rotation = Quaternion.Lerp(j.transform.rotation, Quaternion.Euler(desiredRot), 100f * Time.deltaTime);
        }
    }
}

