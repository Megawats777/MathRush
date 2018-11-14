using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    [SerializeField]
    private float stepInterval = 1.0f;

    [SerializeField]
    private float movementSpeed = 5.0f;

    Vector3 futurePos = Vector3.zero;

    public void setPosition(Vector3 position)
    {
        transform.position = position;
    }



    // Use this for initialization
    void Start()
    {
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
