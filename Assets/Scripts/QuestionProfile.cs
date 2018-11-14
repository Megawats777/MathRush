using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="QuestionProfile", menuName="QuestionProfile")]
public class QuestionProfile : ScriptableObject
{

	// Variables
	[SerializeField]
	private string equation = "1+1";

	[SerializeField]
	private float answer = 2;
    

	// Getter and setters
	public string getEquation()
	{
		return equation;
	}

	public float getAnswer()
	{
		return answer;
	}
}
