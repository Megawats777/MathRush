using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestionProfile", menuName = "QuestionProfile")]
public class QuestionProfile : ScriptableObject
{

    // Equation field and property
    [SerializeField]
    private string equation = "1+1";
    [HideInInspector]
    public string Equation
    {
        get
        {
            return equation;
        }
    }

	// IsCorrect field and property
	[SerializeField]
	private bool isCorrect = false;
	[HideInInspector]
	public bool IsCorrect
	{
		get 
		{
			return isCorrect;
		}
	}

}
