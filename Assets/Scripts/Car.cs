using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]
    private CarMovementProfile movementProfile;

    private float animDuration = 0.01f;


    private Vector3 originalPosition;
    private Vector3 futurePos = Vector3.zero;
    private bool crossedFinishLine = false;

    private FinishLine finishLine;


    private ControllerBase owningController = null;
    private Car enemyCar = null;


    // Getters and setters
    public void setPosition(Vector3 newPosition)
    {
        
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
        futurePos = transform.position;

        if (!owningController)
        {
            Debug.LogError("No Controller assigned for car : " + gameObject.name);
        }

        else
        {
            Debug.Log("Controller assigned to : " + gameObject.name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, futurePos, Time.deltaTime * movementProfile.getMovementSpeed());
    }

    // Move this car
    // forward = true : move the car forward
    // forward = false : move the car backwards
    public void move(bool forward)
    {
        if (forward)
        {
            futurePos.z += movementProfile.getStepInterval();
        }
            
        else
        {
            futurePos.z -= movementProfile.getStepInterval();
        }
    }



    // Draw debug gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
