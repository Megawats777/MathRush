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
            // Get car references
            Car c = other.GetComponent<Car>();

            if (c)
                print("Success");
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
