using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    public bool Endless = false;
    public string Objective = "WIN";
    public float RoundTimer = 30.0f;
    public GameObject EnemyPrefab;
    public int spawnLimit = 15;
    public float spawnRate = 4.0f;
    private float spawnTimer = 0.0f;
    private int spawnIndex = 0;
    public List<Transform> SpawnList = new List<Transform>();

    private bool WinCondition = false;
    private bool LoseCondition = false;

    private GameObject _buttonpanel;
    private bool isPaused = false;

    private List<GameObject> enemyList = new List<GameObject>();
    private int enemyCount = 0;

    public int GetEnemyCount()
    {
        return enemyList.Count;
    }

    public string GetObjective()
    {
        return Objective;
    }

    public float GetRoundTime()
    {
        return RoundTimer;
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        _buttonpanel.SetActive(true);
    }

    private void ResumeGame()
    {
        Time.timeScale = 1.0f;
        _buttonpanel.SetActive(false);
        isPaused = false;
    }

    private bool Win()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            if (enemyList[i] == null)
            {
                enemyList.Remove(enemyList[i]);
            }
        }
        //LIST OF 'ENEMY' GOs IS EMPTY
        if (enemyList.Count <= 0)
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

    private void GatherEnemies()
    {
        //GATHER THE ACTIVE ENEMIES IN THE SCENE
        var getEnemies = GameObject.FindGameObjectsWithTag("enemy");
        if (getEnemies != null)
        {
            for (int i = 0; i < getEnemies.Length; i++)
            {
                if (enemyList.Contains(getEnemies[i]) == false)
                {
                    enemyList.Add(getEnemies[i]);
                }
            }
        }
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

    private void SpawnEnemies()
    {
        if (enemyList.Count > spawnLimit)
        {
            return;
        }

        if (enemyList.Count < spawnLimit)
        {
            if (spawnTimer >= spawnRate)
            {
                if(spawnIndex >= SpawnList.Count)
                {
                    spawnIndex = 0;
                }
                var enemy = (GameObject)Instantiate(EnemyPrefab, SpawnList[spawnIndex].position, SpawnList[spawnIndex].rotation);
                spawnTimer = 0.0f;
                spawnIndex += 1;
            }
        }
    }

    private void Awake()
    {
        if (Time.timeScale < 1.0f)
        {
            Time.timeScale = 1.0f;
        }
    }

    void Start()
    {
        _buttonpanel = GameObject.FindGameObjectWithTag("pauseMenu");

        GatherEnemies();
        RenameEnemies();

        _buttonpanel.SetActive(false);
        isPaused = false;
    }

    void Update()
    {
        if (isPaused == false)
        {
            if (Input.GetButtonDown("Pause"))
            {
                PauseGame();
            }

            if (Endless == true)
            {
                SpawnEnemies();
                spawnTimer += Time.deltaTime;
            }

            GatherEnemies();
            RenameEnemies();

            if (WinCondition && Endless == false)
            {
                //GOTO THE WIN SCENE
                SceneManager.LoadScene("97.win");
            }

            if (LoseCondition && Endless == false)
            {
                //GOTO THE LOSE SCENE
                SceneManager.LoadScene("98.lose");
            }

            //DECREMENT THE ROUND TIMER;
            RoundTimer -= Time.deltaTime;
            LoseCondition = Lose();
            WinCondition = Win();
        }

        if (isPaused == true)
        {
            if (Input.GetButton("Back")) //UNPAUSE THE GAME
            {
                ResumeGame();
            }
        }
    }
}
