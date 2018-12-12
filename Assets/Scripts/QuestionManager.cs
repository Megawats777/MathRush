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
    public QuestionProfile SelectedQuestion
    {
		get
		{
			return selectedQuestion;
		}
    }

	private Text equationText;

    // Called before start
    private void Awake()
    {
		equationText = GameObject.FindGameObjectWithTag("QuestionText").GetComponent<Text>();
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

        print("Selected Question Answer : " + ((selectedQuestion.IsCorrect ? "Correct" : "Incorrect")));
		equationText.text = selectedQuestion.Equation;
        previousQuestion = selectedQuestion;
    }
}
