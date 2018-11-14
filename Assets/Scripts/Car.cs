using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]    
    private CarMovementProfile movementProfile;

    private float stepInterval = 1.0f;
    private float movementSpeed = 5.0f;

    private Vector3 futurePos = Vector3.zero;
    private bool crossedFinishLine = false;

    private FinishLine finishLine;

    [SerializeField]
    private ControllerBase owningController = null;

    // Getters and setters
    public void setPosition(Vector3 position)
    {
        transform.position = position;

        if ((transform.position.x >= finishLine.getXPosition()) && crossedFinishLine == false)
        {
            print("Reached Finish Line");
            crossedFinishLine = true;
        }
    }



    // Called before start
    private void Awake()
    {
        finishLine = FindObjectOfType<FinishLine>();
    }

    // Use this for initialization
    void Start()
    {
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
    public void move()
    {
        futurePos.x += stepInterval;
    }



    // Draw debug gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
