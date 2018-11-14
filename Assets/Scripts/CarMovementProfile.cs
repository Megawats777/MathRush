using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CarMovementProfile", menuName="CarMovementProfile")]
public class CarMovementProfile : ScriptableObject
{
	// Variables
	[SerializeField]
	private float stepInterval = 3;

	[SerializeField]
	private float movementSpeed = 10;


	// Getters
	public float getStepInterval()
	{
		return stepInterval;
	}

	public float getMovementSpeed()
	{
		return movementSpeed;
	}

}
