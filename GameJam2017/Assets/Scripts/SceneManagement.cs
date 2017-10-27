using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour

{

    public void MainMenuLoad()
    {
        SceneManager.LoadScene("0.main", LoadSceneMode.Single);
    }
    public void LoadGarage()
    {
        SceneManager.LoadScene("1.garage", LoadSceneMode.Single);
    }
    public void LoadLevel()
    {
        SceneManager.LoadScene("2.track", LoadSceneMode.Single);

    }
    public void LoadMap1()
    {
        SceneManager.LoadScene("4.Plane", LoadSceneMode.Single);
    }

    public void CityMap()
    {
        SceneManager.LoadScene("2.track", LoadSceneMode.Single);
    }
    public void Lookat()
    {
       

    }
    //public void Options()
    //{
        
    //}
    public void ExitGame()
    {
        Application.Quit();
    }
    // Use this for initialization

 
    // Update is called once per frame

}
