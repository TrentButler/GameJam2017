using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCameraBehaviour : MonoBehaviour
{
    Transform CameraTransform;
    public Transform model;

    private void Awake()
    {
        if(Time.timeScale < 1.0f)
        {
            Time.timeScale = 1.0f;
        }
    }

    void Start()
    {
        model = GameObject.FindGameObjectWithTag("model").transform;
        CameraTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        CameraTransform.RotateAround(model.position, Vector3.up, 20 * Time.deltaTime);
        CameraTransform.LookAt(model);
    }
}
