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
    // Use this for initialization

 
    // Update is called once per frame

}
