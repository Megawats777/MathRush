using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteAlways]
public class CameraAngleController : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    Car pCar;

    // Called before start
    private void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        pCar = GameObject.FindGameObjectWithTag("PlayerCar").GetComponent<Car>();
    }


    // Start is called before the first frame update
    void Start()
    {
        if (Application.isPlaying)
        {
            applyPlayerTrackingSettings();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            applyPlayerTrackingSettings();
        }
    }


    // Apply player tracking settings
    private void applyPlayerTrackingSettings()
    {
        if (pCar)
        {
            cam.Follow = pCar.transform;
            cam.LookAt = pCar.transform;
        }
    }
}
