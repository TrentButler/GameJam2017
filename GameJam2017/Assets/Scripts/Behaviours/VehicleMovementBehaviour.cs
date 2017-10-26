using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovementBehaviour : MonoBehaviour
{
    public enum Gear
    {
        NEUTRAL = 0,
        FIRST = 1,
        SECOND = 2,
        THIRD = 3,
        FOURTH = 4,
        FIFTH = 5,
        REVERSE = 6,
    }

    private Gear transmission = Gear.NEUTRAL;

    public float MaxVehicleSpeed = 0.0f;
    public float MovementSpeed = 10.0f;
    public float MaxSteerAngle = 45.0f;
    public float driftForce = 1.0f;

    public float first = 0.0f;
    public float second = 0.0f;
    public float third = 0.0f;
    public float fourth = 0.0f;
    public float fifth = 0.0f;

    public Vector3 velocity = Vector3.zero;
    private Vector3 force = Vector3.zero;

    private float torque = 0.0f;
    private float MaxWheelTorque = 10.0f;
    private float MaxBrakeForce = 10000.0f;

    private Transform chassis;
    private Rigidbody rb;

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

    private void Transmission()
    {
        //LIMIT SPEED BY THE GEAR
        switch (transmission)
        {
            case (Gear.NEUTRAL):
                {
                    MaxVehicleSpeed = 0.0f;
                    if (velocity.magnitude > MaxVehicleSpeed)
                    {
                        //SLOW DOWN
                    }
                    break;
                }

            case (Gear.FIRST):
                {
                    MaxVehicleSpeed = first;
                    if (velocity.magnitude > MaxVehicleSpeed)
                    {
                        //SLOW DOWN
                    }
                    break;
                }

            case (Gear.SECOND):
                {
                    MaxVehicleSpeed = second;
                    if (velocity.magnitude > MaxVehicleSpeed)
                    {
                        //SLOW DOWN
                    }
                    break;
                }

            case (Gear.THIRD):
                {
                    MaxVehicleSpeed = third;
                    if (velocity.magnitude > MaxVehicleSpeed)
                    {
                        //SLOW DOWN
                    }
                    break;
                }

            case (Gear.FOURTH):
                {
                    MaxVehicleSpeed = fourth;
                    if (velocity.magnitude > MaxVehicleSpeed)
                    {
                        //SLOW DOWN
                    }
                    break;
                }

            case (Gear.FIFTH):
                {
                    MaxVehicleSpeed = fifth;
                    if (velocity.magnitude > MaxVehicleSpeed)
                    {
                        //SLOW DOWN
                    }
                    break;
                }

            case (Gear.REVERSE):
                {
                    MaxVehicleSpeed = 0.0f;
                    break;
                }
        }
    }

    void Start()
    {
        chassis = GameObject.FindGameObjectWithTag("chassis").GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();

        FR = GameObject.FindGameObjectWithTag("FL").GetComponent<Transform>();
        FL = GameObject.FindGameObjectWithTag("FR").GetComponent<Transform>();
        RR = GameObject.FindGameObjectWithTag("RL").GetComponent<Transform>();
        RL = GameObject.FindGameObjectWithTag("RR").GetComponent<Transform>();

        wc_FL = GameObject.FindGameObjectWithTag("wcFL").GetComponent<WheelCollider>();
        wc_FR = GameObject.FindGameObjectWithTag("wcFR").GetComponent<WheelCollider>();
        wc_RL = GameObject.FindGameObjectWithTag("wcRL").GetComponent<WheelCollider>();
        wc_RR = GameObject.FindGameObjectWithTag("wcRR").GetComponent<WheelCollider>();
    }

    void Update()
    {
        Debug.Log(transmission);
    }

    private void FixedUpdate()
    {
        //OUTRUN DRIFTING
        //CALCULATE VEHICLE SPEED (FOR UI)
        //CALCULATE WHEEL RPM (FOR UI)
        //CLEAN THIS UP

        var accel = Input.GetAxis("Accelerate");
        var brake = Input.GetAxis("Brake");
        var steer = Input.GetAxis("Steer");

        #region Drive
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (transmission != Gear.REVERSE)
            {
                transmission += 1;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (transmission != Gear.NEUTRAL)
            {
                transmission -= 1;
            }
        }

        Transmission();

        //LIMIT THE MAX SPEED
        if (velocity.magnitude > MaxVehicleSpeed)
        {
            torque = 0.0f;
        }

        if (velocity.magnitude < MaxVehicleSpeed)
        {
            //ADD TORQUE
            torque += accel * MaxWheelTorque;
        }

        //force = new Vector3(0, 0, torque * MovementSpeed);
        force = new Vector3(0, 0, torque);

        Vector3 acceleration = force * Time.deltaTime;
        velocity = velocity + (acceleration * Time.deltaTime);
        #endregion

        #region Steer
        //LIMIT THIS BASED ON VEHICLE SPEED

        chassis.Rotate(new Vector3(0, steer * 0.5f, 0));

        if (steer * MaxSteerAngle >= 45.0f || steer * MaxSteerAngle <= -45.0f)
        {
            Vector3 slide = new Vector3(driftForce * steer, 0, 0);
            chassis.position += velocity + slide;
        }

        if (steer * MaxVehicleSpeed < 45.0f)
        {
            chassis.Translate(velocity);
        }
        #endregion

        //#region Visuals
        //wc_FL.steerAngle = steer * MaxSteerAngle;
        //wc_FR.steerAngle = steer * MaxSteerAngle;

        //Vector3 flPosition = new Vector3();
        //Quaternion flRotation = new Quaternion();
        //wc_FL.GetWorldPose(out flPosition, out flRotation);

        //Vector3 frPosition = new Vector3();
        //Quaternion frRotation = new Quaternion();
        //wc_FR.GetWorldPose(out frPosition, out frRotation);

        //FL.rotation = flRotation;
        //FL.position = flPosition;

        //FR.rotation = frRotation;
        //FR.position = frPosition;
        //#endregion
    }
}
