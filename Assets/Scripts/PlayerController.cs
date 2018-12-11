using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : ControllerBase
{
    // InputEnabled field and property
    private bool inputEnabled = true;
    public bool InputEnabled
    {
        get
        {
            return inputEnabled;
        }
        set
        {
            inputEnabled = value;
        }
    }

    private QuestionManager questionManager = null;
    private Car controlledCar;

    // Answer button references
    private Button buttonCorrect;
    private Button buttonIncorrect;


    // Called before start
    private void Awake()
    {
        questionManager = FindObjectOfType<QuestionManager>();

        controlledCar = GameObject.FindGameObjectWithTag("PlayerCar").GetComponent<Car>();
        controlledCar.setOwningController(this);


        buttonCorrect = GameObject.FindGameObjectWithTag("Button-Correct").GetComponent<Button>();
        buttonIncorrect = GameObject.FindGameObjectWithTag("Button-Incorrect").GetComponent<Button>();


        // Assign actions to buttons
        assignButtonActions(buttonCorrect, true);
        assignButtonActions(buttonIncorrect, false);
    }


    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard input
        if (inputEnabled)
        {
            if (Input.GetKeyDown(KeyCode.A))
                answerQuestion(true);

            else if (Input.GetKeyDown(KeyCode.D))
                answerQuestion(false);
        }
    }

    // Assign actions to buttons
    private void assignButtonActions(Button bt, bool chosenAnswer)
    {
        bt.onClick.AddListener(() => {

            if (inputEnabled)
                answerQuestion(chosenAnswer);
        
            EventSystem.current.SetSelectedGameObject(null);
        });
    }


    // Answer question
    // chosenAnswer = true  : Thinks equation is correct
    // chosenAnswer = false : Thinks equation is inCorrect 
    private void answerQuestion(bool chosenAnswer)
    {
        // If the chosenAnswer and the IsCorrect value of the selected question are the same
        if (chosenAnswer == questionManager.SelectedQuestion.IsCorrect)
        {
            print("Answer Correct!");
            controlledCar.move(true);
        }

        // If the chosenAnswer is wrong
        else
        {
            print("Answer InCorrect");
            controlledCar.move(false);
        }

        questionManager.selectQuestion();
    }
}