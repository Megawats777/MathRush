using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ControllerBase
{
    private bool inputEnabled = true;

    private QuestionManager questionManager = null;
    private Car controlledCar;


    // Getters and setters
    public bool getIsInputEnabled()
    {
        return inputEnabled;
    }

    public void setIsInputEnabled(bool status)
    {
        inputEnabled = status;
    }

    // Called before start
    private void Awake()
    {
        questionManager = FindObjectOfType<QuestionManager>();

        controlledCar = GameObject.FindGameObjectWithTag("PlayerCar").GetComponent<Car>();
        controlledCar.setOwningController(this);
    }


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inputEnabled)
        {
            
        }
    }

}