using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementBehaviour : MonoBehaviour
{

    public float HorizontalWheelOffset = 2.0f;
    public float AxelOffset = 2.0f;

    public float MovementSpeed = 10.0f;
    public float MaxSteerAngle = 45.0f;

    private Transform chassis;

    #region Wheels
    Transform FR;
    Transform FL;

    Transform RR;
    Transform RL;

    WheelCollider wc_FL;
    WheelCollider wc_FR;

    WheelCollider wc_RL;
    WheelCollider wc_RR;
    #endregion

    // Use this for initialization
    void Start()
    {
        chassis = GameObject.FindGameObjectWithTag("chassis").GetComponent<Transform>();

        #region GetWheels
        FR = GameObject.FindGameObjectWithTag("FL").GetComponent<Transform>();
        FL = GameObject.FindGameObjectWithTag("FR").GetComponent<Transform>();
        RR = GameObject.FindGameObjectWithTag("RL").GetComponent<Transform>();
        RL = GameObject.FindGameObjectWithTag("RR").GetComponent<Transform>();

        wc_FL = GameObject.FindGameObjectWithTag("wcFL").GetComponent<WheelCollider>();
        wc_FR = GameObject.FindGameObjectWithTag("wcFR").GetComponent<WheelCollider>();
        wc_RL = GameObject.FindGameObjectWithTag("wcRL").GetComponent<WheelCollider>();
        wc_RR = GameObject.FindGameObjectWithTag("wcRR").GetComponent<WheelCollider>();
        #endregion

        //OFFSET THE RIGHT WHEEL FROM THE LEFT
        //OFFSET THE REAR WHEELS FROM THE FRONT
        FR.position = new Vector3(FL.position.x + HorizontalWheelOffset, FL.position.y, FL.position.z);

        RL.position = new Vector3(FL.position.x, FL.position.y, FL.position.z - AxelOffset);
        RR.position = new Vector3(FL.position.x + HorizontalWheelOffset, FL.position.y, FL.position.z - AxelOffset);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        //ACCELERATE
        //BRAKE
        //STEER

        //OUTRUN DRIFTING
        //CALCULATE VEHICLE SPEED (FOR UI)
        //CALCULATE WHEEL RPM (FOR UI)
        //CLEAN THIS UP

        //ROTATE THE CHASSIS BASED ON THE WHEEL ANGLE
        
        var accel = Input.GetAxis("Accelerate");
        var brake = Input.GetAxis("Brake");
        var steer = Input.GetAxis("Steer");

        Vector3 move = new Vector3(0, 0, accel * MovementSpeed);

        //ROTATE THE WHEEL COLLIDERS
        wc_FL.steerAngle = steer * MaxSteerAngle;
        wc_FR.steerAngle = steer * MaxSteerAngle;

        wc_RL.motorTorque = accel * MovementSpeed;
        wc_RR.motorTorque = accel * MovementSpeed;

        chassis.position += move * Time.deltaTime;
    }
}
