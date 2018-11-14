using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : ControllerBase
{
    private string answerString = "";
    private int answerNum = 0;

    private Text inputText;
    private QuestionManager questionManager;
    private Car controlledCar;

    // Called before start
    private void Awake()
    {
        inputText = GameObject.FindGameObjectWithTag("PlayerInputText").GetComponent<Text>();
        questionManager = FindObjectOfType<QuestionManager>();
        controlledCar = GameObject.FindGameObjectWithTag("PlayerCar").GetComponent<Car>();
    }


    // Use this for initialization
    void Start()
    {
        inputText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        // Number input
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))
        {
            addToAnswer('0');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            addToAnswer('1');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            addToAnswer('2');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            addToAnswer('3');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            addToAnswer('4');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            addToAnswer('5');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))
        {
            addToAnswer('6');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))
        {
            addToAnswer('7');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))
        {
            addToAnswer('8');
        }

        else if (Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))
        {
            addToAnswer('9');
        }

        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            removeFromAnswer();
        }

		else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			confirmAnswer();
		}
    }

    // Add to answer
    private void addToAnswer(char numChar)
    {
        if (answerString.Length < 10)
        {
            answerString += numChar;
            inputText.text = answerString;
        }
    }

    // Remove from answer
    private void removeFromAnswer()
    {
        if (answerString.Length > 0)
        {
        	answerString = answerString.Substring(0, answerString.Length - 1);
			inputText.text = answerString;
        }
    }

	// Confirm answer
	private void confirmAnswer()
	{
		if (string.IsNullOrEmpty(answerString) == false)
		{
			answerNum = int.Parse(answerString);
		
            // Check if the answer is correct
            if (answerNum == questionManager.getSelectedQuestion().getAnswer())
            {
                controlledCar.move();                
            }
            else
            {
                
            }
        
        }
		else
		{
			print("No answer entered");
		}

		answerString = "";
		inputText.text = answerString;

        questionManager.selectQuestion();
	}
}
