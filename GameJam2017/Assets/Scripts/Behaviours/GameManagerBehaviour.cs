﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour {
    
    public float RoundTimer = 30.0f;
    bool WinCondition = false;
    bool LoseCondition = false;
    
    public List<GameObject> Pins = new List<GameObject>();

    private bool Win()
    {
        for(int i = 0; i < Pins.Count; i++)
        {
            if(Pins[i] == null)
            {
                Pins.Remove(Pins[i]);
            }
        }
        //LIST OF 'ENEMY' GOs IS EMPTY
        if(Pins.Count <= 0)
        {
            return true;
        }
        return false;
    }

    private bool Lose()
    {
        if(RoundTimer <= 0.0f)
        {
            return true;
        }
        return false;
    }

	// Use this for initialization
	void Start ()
    {
        //GATHER THE ACTIVE ENEMIES IN THE SCENE
        var getEnemies = GameObject.FindGameObjectsWithTag("enemy");
        if(getEnemies != null)
        {
            for(int i = 0; i < getEnemies.Length; i++)
            {
                Pins.Add(getEnemies[i]);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(WinCondition)
        {
            //GOTO THE WIN SCENE
            SceneManager.LoadScene("97.win");
        }

        if (LoseCondition)
        {
            //GOTO THE LOSE SCENE
            SceneManager.LoadScene("98.lose");
        }

        //DECREMENT THE ROUND TIMER;
        RoundTimer -= Time.deltaTime;
        LoseCondition = Lose();
        WinCondition = Win();
    }
}