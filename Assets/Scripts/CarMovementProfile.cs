using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="CarMovementProfile", menuName="CarMovementProfile")]
public class CarMovementProfile : ScriptableObject
{
	// Variables
	[SerializeField]
	private float stepInterval = 3;
    [HideInInspector]
    public float StepInterval
    {
        get
        {
            return stepInterval;
        }
    }

	[SerializeField]
	private float animationSpeed = 10;
    [HideInInspector]
    public float AnimationSpeed
    {
        get
        {
            return animationSpeed;
        }
    }

}
