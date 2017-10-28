using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class InGameUIBehaviour : MonoBehaviour
{
    private Text EnemyCount;
    private Text RoundTimer;
    private Text Objective;
    
    GameManagerBehaviour manager;
    
	void Start ()
    {
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<GameManagerBehaviour>();
        EnemyCount = GameObject.FindGameObjectWithTag("enemyCount").GetComponent<Text>();
        Objective = GameObject.FindGameObjectWithTag("objectiveText").GetComponent<Text>();
        RoundTimer = GameObject.FindGameObjectWithTag("timerText").GetComponent<Text>();
	}
	
	void Update ()
    {
        string objective = "Objective: " + manager.GetObjective();
        string timer = "Time Left: " + manager.GetRoundTime();

        Objective.text = objective;
        RoundTimer.text = timer;

        if(manager.Endless == false)
        {
            //DISPLAY THE TIMER
            RoundTimer.gameObject.SetActive(true);
        }

        if (manager.Endless == true)
        {
            //DO NOT DISPLAY THE TIMER
            RoundTimer.gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        string enemiesRemaining = "Enemies Remaining: " + manager.GetEnemyCount();
        EnemyCount.text = enemiesRemaining;
    }
}
