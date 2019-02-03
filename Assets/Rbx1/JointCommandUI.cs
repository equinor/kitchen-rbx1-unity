using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JointCommandUI : MonoBehaviour
{

    public GameObject[] Joints;
    public GameObject RosConnector;

    private Float64MultiArrayPublisher jointPub;
    private Float64MultiArrayPublisher gripperPub;
    private RosConnector ros;
    private float time = 0.0F;
    private string goToPosString = "0.0,0.0,0.0,0.0,0.0,0.0,0.0";
    private bool isKeyToggled;

    void Start() {
        var publishers = RosConnector.GetComponents<Float64MultiArrayPublisher>();
        jointPub = publishers.FirstOrDefault();
        gripperPub = publishers.LastOrDefault();
        ros = RosConnector.GetComponent<RosConnector>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) isKeyToggled = !isKeyToggled;
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

        const int labelY = 30;
        GUI.Label(new Rect(20, labelY, 70, 30), "Shoulder");
        GUI.Label(new Rect(90, labelY, 50, 30), moveTo[0].ToString("0.00"));
        GUI.Label(new Rect(20, labelY + 20, 70, 30), "Arm");
        GUI.Label(new Rect(90, labelY + 20, 50, 30), moveTo[1].ToString("0.00"));
        GUI.Label(new Rect(20, labelY + 40, 70, 30), "Upper");
        GUI.Label(new Rect(90, labelY + 40, 50, 30), moveTo[2].ToString("0.00"));
        GUI.Label(new Rect(20, labelY + 60, 70, 30), "Forearm");
        GUI.Label(new Rect(90, labelY + 60, 50, 30), moveTo[3].ToString("0.00"));
        GUI.Label(new Rect(20, labelY + 80, 70, 30), "Wrist");
        GUI.Label(new Rect(90, labelY + 80, 50, 30), moveTo[4].ToString("0.00"));
        GUI.Label(new Rect(20, labelY + 100, 70, 30), "Hand");
        GUI.Label(new Rect(90, labelY + 100, 50, 30), moveTo[5].ToString("0.00"));

        if (GUI.Button(new Rect(25, 180, 100, 30), "Home"))
        {
            jointPub.PublishPosition(new float[] {0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f} );
        }

        time = time + Time.deltaTime;
        if (GUI.Button(new Rect(25, 210, 100, 30), "Apply") || (Input.GetButton("FireJoy") && time > 0.5f))
        {
            jointPub.PublishPosition(moveTo);

            var gripAngle = getAngle(Joints[6]);
            gripperPub.PublishPosition(new float[] {gripAngle, gripAngle});
            time = 0.0f;
        }

        if(isKeyToggled) {
            goToPosString = GUI.TextField (new Rect (25, 270, 140, 30), goToPosString);
            if (GUI.Button(new Rect(25, 305, 100, 30), "Pose"))
            {
                ApplyPoseIfValid(goToPosString);
            }

            if (GUI.Button(new Rect(25, 335, 100, 30), "Reset"))
            {
                goToPosString = "";
            }
        }
    }

    private void ApplyPoseIfValid(string text) {
        if (text == null) return;
        var numberArray = text.Split(',');
        if (numberArray.Count() < 7) return;
        try
        {
            float[] numbers = numberArray.Select(float.Parse).ToArray();
            for(var i = 0; i < Joints.Count(); i += 1) {
                var writer = Joints[i].GetComponent<JointMover>();
                writer.SetState(numbers[i]);
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
            return;
        }  
    }

    private float getAngle(GameObject jointObject)
    {
        var hingeJoint = jointObject.GetComponent<JointStateWriter>();
        return hingeJoint.newState;
    } 
}

