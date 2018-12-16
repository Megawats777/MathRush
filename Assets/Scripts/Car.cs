using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Car : MonoBehaviour
{
    
    [SerializeField]
    private CarMovementProfile movementProfile;
    [SerializeField]
    private Direction direction;
    private Transform rotationRoot;

    private Vector3 originalPosition;
    private Vector3 futurePos = Vector3.zero;


    private bool crossedFinishLine = false;
    private FinishLine finishLine;


    private ControllerBase owningController = null;
    private Car enemyCar = null;



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
        rotationRoot = transform.Find("MeshRotationRoot");
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

        setDisplayMeshRotation();

        if (Application.isPlaying)
        {
            if (!owningController)
            {
                Debug.LogError("No Controller assigned for car : " + gameObject.name);
            }

            else
            {
                Debug.Log("Controller assigned to : " + gameObject.name);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        // EDITOR CODE
        if (Application.isPlaying == false)
        {
            setDisplayMeshRotation();
        }

        else
        {        
            transform.position = Vector3.Lerp(transform.position, futurePos, Time.deltaTime * movementProfile.AnimationSpeed);
        }

    }

    // Clamp position variables
    private void clampPositionVariables(ref Vector3 vec)
    {
        if (direction == Direction.Forward)
        {
            vec.z = Mathf.Clamp(vec.z, originalPosition.z - movementProfile.StepInterval, 99999);
        }

        else
        {
            vec.x = Mathf.Clamp(vec.x, originalPosition.x - movementProfile.StepInterval, 99999);
        }
    }


    // Move this car
    // advance = true : Advance the car through the level
    // advance = false : Reverse the car's progression through the level
    public void move(bool advance)
    {
        if (advance)
        {
            if (direction == Direction.Forward)
            {
                futurePos.z += movementProfile.StepInterval;
            }

            else
            {
                futurePos.x += movementProfile.StepInterval;
            }
        }

        else
        {
            if (direction == Direction.Forward)
            {
                futurePos.z -= movementProfile.StepInterval;
            }

            else
            {
                futurePos.x -= movementProfile.StepInterval;
            }
        }

        clampPositionVariables(ref futurePos);
    }


    // Set rotation of display mesh
    private void setDisplayMeshRotation()
    {
        rotationRoot.localPosition = Vector3.zero;
        rotationRoot.localScale = Vector3.one;

        if (direction == Direction.Right)
            rotationRoot.eulerAngles = new Vector3(0, 90, 0);
        else
            rotationRoot.eulerAngles = Vector3.zero;
    }



    // Draw debug gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}
