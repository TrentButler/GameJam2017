using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetVehicleInfoBehaviour : MonoBehaviour {

    //WHAT DO I NEED?
    //WHEEL RPM
    private WheelCollider RR;

    public float RPM = 0.0f;
    public float MPH = 0.0f;

    //MAYBE...
    //public float Fuel;
    //public Ammo ammo;
	
	void Start ()
    {
        RR = GameObject.FindGameObjectWithTag("wcRR").GetComponent<WheelCollider>();	
	}

    private void FixedUpdate()
    {
        //CALCULATE THE SPEED
        RPM = RR.rpm;

        //CONVERT TO MPH
        MPH = RR.radius * Mathf.PI * RPM * 60.0f / 1000.0f;
    }

}
