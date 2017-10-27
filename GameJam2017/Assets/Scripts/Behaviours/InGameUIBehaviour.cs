using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InGameUIBehaviour : MonoBehaviour
{
    ScoreManagerBehaviour manager;
	// Use this for initialization
	void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<ScoreManagerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
