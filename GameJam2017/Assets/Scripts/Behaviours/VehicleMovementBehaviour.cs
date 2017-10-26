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
    
    public float MovementSpeed = 10.0f;
    public float MaxSteerAngle = 45.0f;

    public float RRwheelRPM = 0.0f;
    public float RLwheelRPM = 0.0f;

    private float torque = 0.0f;
    private float MaxWheelRPM = 0.0f;

    private float MaxWheelTorque = 10.0f;
    private float MaxBrakeForce = 10000.0f;
    
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
                    MaxWheelRPM = 0.0f;
                    break;
                }

            case (Gear.FIRST):
                {
                    MaxWheelRPM = 2500.0f;
                    break;
                }

            case (Gear.SECOND):
                {
                    MaxWheelRPM = 3500.0f;
                    break;
                }

            case (Gear.THIRD):
                {
                    MaxWheelRPM = 4500.0f;
                    break;
                }

            case (Gear.FOURTH):
                {
                    MaxWheelRPM = 5500.0f;
                    break;
                }

            case (Gear.FIFTH):
                {
                    MaxWheelRPM = 6500.0f;
                    break;
                }

            case (Gear.REVERSE):
                {
                    MaxWheelRPM = 0.0f;
                    break;
                }
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        //FR = GameObject.FindGameObjectWithTag("FL").GetComponent<Transform>();
        //FL = GameObject.FindGameObjectWithTag("FR").GetComponent<Transform>();
        //RR = GameObject.FindGameObjectWithTag("RL").GetComponent<Transform>();
        //RL = GameObject.FindGameObjectWithTag("RR").GetComponent<Transform>();

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

        torque = accel * MaxWheelTorque;

        Vector3 move = new Vector3(0, 0, torque * MovementSpeed);

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
        
        if (wc_RR.rpm > MaxWheelRPM || wc_RL.rpm > MaxWheelRPM)
        {
            wc_RL.motorTorque = 0.0f;
            wc_RR.motorTorque = 0.0f;
        }

        if (wc_RR.rpm < MaxWheelRPM && wc_RL.rpm < MaxWheelRPM)
        {
            wc_RL.motorTorque = torque;
            wc_RR.motorTorque = torque;
        }

        //ROTATE THE WHEEL COLLIDERS
        wc_FL.steerAngle = steer * MaxSteerAngle;
        wc_FR.steerAngle = steer * MaxSteerAngle;

        wc_FL.brakeTorque = brake * MaxBrakeForce;
        wc_FR.brakeTorque = brake * MaxBrakeForce;
        wc_RL.brakeTorque = brake * MaxBrakeForce;
        wc_RR.brakeTorque = brake * MaxBrakeForce;

        RRwheelRPM = wc_RR.rpm;
        RLwheelRPM = wc_RL.rpm;
        #endregion
    }
}
