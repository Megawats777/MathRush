﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]
    private CarMovementProfile movementProfile;

    private float stepInterval = 1.0f;
    private float movementSpeed = 5.0f;

    private Vector3 originalPosition;
    private Vector3 futurePos = Vector3.zero;
    private bool crossedFinishLine = false;

    private FinishLine finishLine;


    private ControllerBase owningController = null;
    private Car enemyCar = null;


    // Getters and setters
    public void setPosition(Vector3 newPosition)
    {
        newPosition.x = Mathf.Clamp(newPosition.x, originalPosition.x, 999999);
        transform.position = newPosition;


        // If this car crossed the finish line
        if ((transform.position.x >= finishLine.getXPosition()) && crossedFinishLine == false)
        {
            print("Reached Finish Line");


            // If the owning controller is Player 1
            if (owningController.getPlayerId() == 1)
            {
                bool playerOneWins = false;

                PlayerController pc = (PlayerController)owningController;
                pc.InputEnabled = false;

                FindObjectOfType<GameplayUi>().hide();

                // If this car crossed the finish line first
                if (enemyCar.getHasCrossedFinishLine() == false)
                {
                    playerOneWins = true;
                    print("Player 1 Wins!");
                }

                FindObjectOfType<GameOverUi>().show(playerOneWins);
            }

            // If the owning controller is not Player 1
            else
            {
                EnemyController ec = (EnemyController)owningController;
                ec.stopMovingAssignedCar();

                // If this car crossed the finish line first
                if (enemyCar.getHasCrossedFinishLine() == false)
                {
                    print("Player " + ec.getPlayerId() + " wins");
                }
            }

            crossedFinishLine = true;
        }
    }


    public void setOwningController(ControllerBase controller)
    {
        owningController = controller;
    }


    public bool getHasCrossedFinishLine()
    {
        return crossedFinishLine;
    }


    // Called before start
    private void Awake()
    {
        finishLine = FindObjectOfType<FinishLine>();


        // Get the enemy car 
        foreach (Car c in FindObjectsOfType<Car>())
        {
            if (c && c.tag != this.tag)
            {
                // If the current car in the list does not have the same tag
                // as this car then mark it as the enemy car
                enemyCar = c;
            }
        }
    }

    // Use this for initialization
    void Start()
    {
        originalPosition = transform.position;

        if (movementProfile)
        {
            stepInterval = movementProfile.getStepInterval();
            movementSpeed = movementProfile.getMovementSpeed();
        }

        if (!owningController)
        {
            Debug.LogError("No Controller assigned for car : " + gameObject.name);
        }

        else
        {
            Debug.Log("Controller assigned to : " + gameObject.name);
        }

        futurePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        setPosition(Vector3.Lerp(transform.position, futurePos, Time.deltaTime * movementSpeed));
    }

    // Move this car
    // forward = true : move the car forward
    // forward = false : move the car backwards
    public void move(bool forward)
    {
        if (forward)
            futurePos.x += stepInterval;
        else
        {
            futurePos.x -= stepInterval;
            futurePos.x = Mathf.Clamp(futurePos.x, originalPosition.x, 999999);
        }
    }



    // Draw debug gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}