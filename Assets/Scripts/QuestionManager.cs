using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
	[SerializeField]
	private QuestionProfile[] questionList;

	private QuestionProfile previousQuestion = null;
	private QuestionProfile selectedQuestion = null;
	private Text questionText;

	// Getters and setters
	public QuestionProfile getSelectedQuestion()
	{
		return selectedQuestion;
	}


	// Called before start
	private void Awake()
	{
		questionText = GameObject.FindGameObjectWithTag("QuestionText").GetComponent<Text>();
	}

    // Use this for initialization
    void Start()
    {
		selectQuestion();
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	// Select question
	public void selectQuestion()
	{
		selectedQuestion = null;

		do 
		{
			selectedQuestion = questionList[Random.Range(0, questionList.Length)];
		} while (selectedQuestion == previousQuestion);

		previousQuestion = selectedQuestion;
		questionText.text = selectedQuestion.getEquation();
	}
}
