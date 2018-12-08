using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointHandMover : MonoBehaviour {

    public string axis;
    public float speed = 10.0f;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis(axis) * speed;
        transform.Rotate(0f, 0f, translation, Space.Self);
    }
}
