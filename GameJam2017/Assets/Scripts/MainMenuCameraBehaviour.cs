using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraBehaviour : MonoBehaviour

{
public Vector3 translation = Vector3.zero;
public float RotateSpeed = 1.0f;
Transform CameraTransform;

public Transform model;

	// Use this for initialization
	void Start ()
    {
       //model = GameObject.FindGameObjectWithTag("model").transform;
        CameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        CameraTransform.RotateAround(model.position, Vector3.up, 20 * Time.deltaTime);
        CameraTransform.LookAt(model);
    }
}
