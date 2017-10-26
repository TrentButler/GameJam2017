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
    
	void Start ()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
        car = GameObject.FindGameObjectWithTag("chassis").transform;
    }

    private void FixedUpdate()
    {
        target = car;

        //if (Input.GetKey(KeyCode.UpArrow))
        //{
        //    CamZ += 1.0f;
        //}

        //if (Input.GetKey(KeyCode.DownArrow))
        //{
        //    CamZ -= 1.0f;
        //}

        var angle = Input.GetAxis("Steer");
        float turnCamera = angle * CameraTurnAngle;
        //Vector3 position = new Vector3(CamX += angle, CamY, CamZ);
        Vector3 cameraOffset = new Vector3(CamX, CamY, CamZ);

        Camera.transform.LookAt(target);
        //Camera.Rotate(Vector3.up, (angle * 0.5f) * CameraTurnAngle);
        //Camera.Rotate(Vector3.up, (angle) * CameraTurnAngle);
        //Camera.Rotate(Vector3.up, turnCamera);
        //Camera.rotation = Quaternion.Euler(new Vector3(0, turnCamera, 0));
        Camera.position = target.position + cameraOffset;
    }

}
