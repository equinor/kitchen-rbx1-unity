using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointCommandUI : MonoBehaviour
{

    public GameObject[] Joints;
    public GameObject RosConnector;

    private Float64MultiArrayPublisher pub;
    private RosConnector ros;

    void Start() {
        pub = RosConnector.GetComponent<Float64MultiArrayPublisher>();
        ros = RosConnector.GetComponent<RosConnector>();
    }

    void OnGUI()
    {
        var moveTo = new float[] { getAngle(Joints[0]), getAngle(Joints[1]),
                getAngle(Joints[2]), getAngle(Joints[3]), getAngle(Joints[4]), getAngle(Joints[5]) };

        GUI.Box(new Rect(10, 10, 130, 240), "");
        if (ros.ConnectionStatus) {
            GUI.Label(new Rect(20, 10, 90, 30), "Connected");
        }
        else {
            GUI.Label(new Rect(20, 10, 90, 30), "Disconnected");
        }

        GUI.Label(new Rect(20, 30, 70, 30), "Shoulder");
        GUI.Label(new Rect(90, 30, 50, 30), moveTo[0].ToString("0.00"));
        GUI.Label(new Rect(20, 50, 70, 30), "Arm");
        GUI.Label(new Rect(90, 50, 50, 30), moveTo[1].ToString("0.00"));
        GUI.Label(new Rect(20, 70, 70, 30), "Upper");
        GUI.Label(new Rect(90, 70, 50, 30), moveTo[2].ToString("0.00"));
        GUI.Label(new Rect(20, 90, 70, 30), "Forearm");
        GUI.Label(new Rect(90, 90, 50, 30), moveTo[3].ToString("0.00"));
        GUI.Label(new Rect(20, 110, 70, 30), "Wrist");
        GUI.Label(new Rect(90, 110, 50, 30), moveTo[4].ToString("0.00"));
        GUI.Label(new Rect(20, 130, 70, 30), "Hand");
        GUI.Label(new Rect(90, 130, 50, 30), moveTo[5].ToString("0.00"));
        if (GUI.Button(new Rect(25, 210, 100, 30), "Apply"))
        {
            pub.PublishPosition(moveTo);
        }
    }

    private float getAngle(GameObject jointObject)
    {
        var hingeJoint = jointObject.GetComponent<JointStateWriter>();
        return hingeJoint.newState;
    } 
}

