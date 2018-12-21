using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointButtonMover : MonoBehaviour {

	public string IncrementButton;
	public string DecrementButton;
    public float Speed = 1.0f;
    private JointStateWriter joint;
    private float newState;
	// Use this for initialization
	void Start () {
        joint = GetComponent<JointStateWriter>();
        newState = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButton(IncrementButton)) {
        	newState +=  Speed * 0.05f;
        	joint.Write(newState);
		}
		else if (Input.GetButton(DecrementButton)) {
			newState += Speed * -0.05f;
			joint.Write(newState);
		}

    }
}
