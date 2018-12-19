using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : ControllerBase
{

    [SerializeField]
    private float initialMoveCommandDelay = 0.5f;


    [SerializeField, Tooltip("How frequently this controller moves their assigned car")]
    private float moveCommandInterval = 1.15f;

    private Car controlledCar;


    // Called before start
    private void Awake()
    {
        controlledCar = GameObject.FindGameObjectWithTag("EnemyCar").GetComponent<Car>();
        controlledCar.OwningController = this;
    }


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Move assigned car
    private void moveAssignedCar()
    {
        controlledCar.move(true);
    }

    // Start moving assigned car
    public void startMovingAssignedCar()
    {
        InvokeRepeating("moveAssignedCar", initialMoveCommandDelay, moveCommandInterval);
    }

    // Stop moving assigned car
    public void stopMovingAssignedCar()
    {
        CancelInvoke("moveAssignedCar");
    }
}
