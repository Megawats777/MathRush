using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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


    [HideInInspector]
    public bool crossedFinishLine = false;
    private FinishLine finishLine;


    private ControllerBase owningController = null;
    [HideInInspector]
    public ControllerBase OwningController
    {
        get
        {
            return owningController;
        }

        set
        {
            owningController = value;
        }
    }

    [HideInInspector]
    public Car EnemyCar
    {
        get;
        set;
    }

    private Text positionText;
    private Rigidbody rb;


    // Called before start
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        rotationRoot = transform.Find("MeshRotationRoot");
        finishLine = FindObjectOfType<FinishLine>();
        positionText = GameObject.FindGameObjectWithTag("PositionText").GetComponent<Text>();


        // Get the enemy car 
        foreach (Car c in FindObjectsOfType<Car>())
        {
            if (c && c.tag != this.tag)
            {
                // If the current car in the list does not have the same tag
                // as this car then mark it as the enemy car
                EnemyCar = c;
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
    }

    // Called before physics update
    private void FixedUpdate()
    {
        rb.MovePosition(Vector3.Lerp(transform.position, futurePos, Time.deltaTime * movementProfile.AnimationSpeed));

        // If the owning controller of this car has an ID of 1
        if (OwningController.getPlayerId() == 1)
        {
            // Update the position text depending if the this car is ahead of the enemy car
            if (direction == Direction.Forward)
            {
                comparePositions(transform.position.z, EnemyCar.transform.position.z);
            }

            else
            {
                comparePositions(transform.position.x, EnemyCar.transform.position.x);
            }
        }

    }

    // Compare positions
    private void comparePositions(float currentCarPos, float enemyCarPos)
    {
        if (positionText)
        {
            if (currentCarPos > enemyCarPos)
            {
                positionText.text = "1 / 2";
            }

            else
            {
                positionText.text = " 2 / 2";
            }
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
