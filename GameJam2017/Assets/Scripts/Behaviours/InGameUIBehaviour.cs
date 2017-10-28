using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InGameUIBehaviour : MonoBehaviour
{
    public Text EnemyCount;
    ScoreManagerBehaviour manager;
	// Use this for initialization
	void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<ScoreManagerBehaviour>();
        EnemyCount = GameObject.FindGameObjectWithTag("enemyCount").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        var MPH = manager.MPH;
        var RPM = manager.RPM;
        var Score = manager.Score;
        string sMPH = "MPH:" + MPH;
        string sRPM = "RPM:" + RPM;
        string sScore = "Enemies Remaining:" + Score;

        EnemyCount.text = sScore;
    }
}
