using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointMover : MonoBehaviour {

    public string axis;
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        float translation = Input.GetAxis(axis) * speed;
        transform.Rotate(translation, 0f, 0f, Space.Self);
    }
}
