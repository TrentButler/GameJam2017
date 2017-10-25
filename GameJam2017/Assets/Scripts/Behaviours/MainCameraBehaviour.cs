using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraBehaviour : MonoBehaviour {

    
    private Transform car;
    private Transform target;
    private Transform Camera;

    public float CamX = 0;
    public float CamY = 10;
    public float CamZ = -35;
    public float CameraTurnAngle = 2;

	// Use this for initialization
	void Start ()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        car = GameObject.FindGameObjectWithTag("chassis").transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //CHECK THE PLAYER STATE
        //DETERMINE THE CAMERA'S 'target'

        target = car;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            CamZ += 1.0f;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            CamZ -= 1.0f;
        }

        //var angle = Input.GetAxis("Steer");
        var angle = 1.0f;

        //Vector3 position = new Vector3(CamX += angle, CamY, CamZ);
        Vector3 position = new Vector3(CamX, CamY, CamZ);

        Camera.transform.LookAt(target);
        //Camera.Rotate(Vector3.up, angle * CameraTurnAngle);        
        Camera.position = target.position + position;
    }

    private void FixedUpdate()
    {
        
    }

}
