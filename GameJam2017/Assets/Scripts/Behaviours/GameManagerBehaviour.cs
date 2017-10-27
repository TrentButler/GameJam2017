using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{

    public float RoundTimer = 30.0f;
    bool WinCondition = false;
    bool LoseCondition = false;
    private ScoreManagerBehaviour score;

    private GameObject _buttonpanel;


    public List<GameObject> Pins = new List<GameObject>();

    private void PauseGame()
    {
        Time.timeScale = 0;
        _buttonpanel.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _buttonpanel.SetActive(false);
    }

    private bool Win()
    {
        for (int i = 0; i < Pins.Count; i++)
        {
            if (Pins[i] == null)
            {
                Pins.Remove(Pins[i]);
            }
        }
        //LIST OF 'ENEMY' GOs IS EMPTY
        if (Pins.Count <= 0)
        {
            return true;
        }
        return false;
    }

    private bool Lose()
    {
        if (RoundTimer <= 0.0f)
        {
            return true;
        }
        return false;
    }

    private void RenameEnemies()
    {
        var all = GameObject.FindGameObjectsWithTag("originalModel");
        for (int i = 0; i < all.Length; i++)
        {
            all[i].name = "originalModel" + i;
            all[i].GetComponentInParent<EnemyBehaviour>().id = i;
        }
    }

    // Use this for initialization
    void Start()
    {
        score = GetComponentInParent<ScoreManagerBehaviour>();
        //GATHER THE ACTIVE ENEMIES IN THE SCENE
        var getEnemies = GameObject.FindGameObjectsWithTag("enemy");
        if (getEnemies != null)
        {
            for (int i = 0; i < getEnemies.Length; i++)
            {
                Pins.Add(getEnemies[i]);
            }
        }
        RenameEnemies();
    }

    // Update is called once per frame
    void Update()
    {

        var pause = Input.GetAxis("Pause");

        if (pause > 0.0f && Time.timeScale >= 1.0f)
        {
            PauseGame();
        }

        if (Time.timeScale <= 0.0f && pause > 0.0f) //UNPAUSE THE GAME
        {
            ResumeGame();
        }

        RenameEnemies();

        score.Score = Pins.Count;

        if (WinCondition)
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
