using RosSharp.RosBridgeClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMover : MonoBehaviour {

    public string axis;
    public float speed = 10.0f;
    private JointStateWriter joint;
    private float newState;
	// Use this for initialization
	void Start () {
        joint = GetComponent<JointStateWriter>();
        newState = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis(axis) * speed * 0.05f;
        newState += translation;
        joint.Write(newState);
    }

    public void SetState(float angle) {
        newState = angle;
    }
}
