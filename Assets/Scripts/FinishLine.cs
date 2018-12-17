using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class FinishLine : MonoBehaviour
{
    private GameObject displayMesh;
    private BoxCollider bc;

    // Getters and setters
    public Vector3 getPosition()
    {
        return transform.position;
    }


    // Called before start
    private void Awake()
    {
        displayMesh = transform.Find("DisplayMesh").gameObject;
        bc = GetComponent<BoxCollider>();
    }


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying == false)
        {
            transform.localScale = Vector3.one;
            displayMesh.transform.localScale = new Vector3(bc.size.x, displayMesh.transform.localScale.y, bc.size.z);
        }
    }


    // When an object enters the box trigger
    private void OnTriggerEnter(Collider other)
    {
        // If the overlapping objects are cars
        if (other.CompareTag("PlayerCar") || other.CompareTag("EnemyCar"))
        {
            bool player1WinStatus = false;
            Car c = other.GetComponent<Car>();
            
            c.crossedFinishLine = true;

            // When the Player's car has entered the trigger
            if (other.CompareTag("PlayerCar"))
            {
                PlayerController pc = (PlayerController)c.OwningController;
                pc.InputEnabled = false;
            
            
                // If the enemy car has not crossed the finish line
                if (c.EnemyCar.crossedFinishLine == false)
                {
                    player1WinStatus = true;
                }


                // Toggle UI
                FindObjectOfType<GameplayUi>().hide();
                FindObjectOfType<GameOverUi>().show(player1WinStatus);
            }

            // When the enemy car has entered the trigger
            else if (other.CompareTag("EnemyCar"))
            {
                EnemyController ec = (EnemyController)c.OwningController;
                ec.stopMovingAssignedCar();
            }
        }
    }




    // Draw debug gizmos
    private void OnDrawGizmos()
    {

        Gizmos.color = new Color(0, 1, 0.25f, 0.5f);
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawCube(Vector3.zero, bc.size);

        Gizmos.color = new Color(0, 1, 0.25f, 1.0f);
        Gizmos.DrawWireCube(Vector3.zero, bc.size);
    }
}
