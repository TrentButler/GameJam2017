using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerBehaviour : MonoBehaviour {
    
    //GET THE VEHICLE INFO
    private GetVehicleInfoBehaviour info;
    
    //STORE THE INFO
    //[HideInInspector]
    public float RPM;
    //[HideInInspector]
    public float MPH;
    [HideInInspector]
    public int Score;

    //SEND IT OUT
    public float GetRPM()
    {
        return RPM;
    }

    public float GetMPH()
    {
        return MPH;
    }

    public int GetScore()
    {
        return Score;
    }

    // Use this for initialization
    void Start ()
    {
        info = GameObject.FindGameObjectWithTag("chassis").GetComponent<GetVehicleInfoBehaviour>();	    	
	}

    private void FixedUpdate()
    {
        RPM = info.RPM;
        MPH = info.MPH;
        //CALCULATE THE SCORE HERE
    }
}
