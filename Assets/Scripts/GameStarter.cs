using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    int startCounter = 5;

    StartingPhaseUi startingPhaseUi;
    GameplayUi gameplayUi;
    
    QuestionManager questionManager;
    PlayerController playerController;
    EnemyController enemyController;


    // Called before start
    private void Awake()
    {
        startingPhaseUi = FindObjectOfType<StartingPhaseUi>();
        gameplayUi = FindObjectOfType<GameplayUi>();
        
        questionManager = FindObjectOfType<QuestionManager>();
        playerController = FindObjectOfType<PlayerController>();
        enemyController = FindObjectOfType<EnemyController>();
    }


    // Start is called before the first frame update
    void Start()
    {
        startingPhaseUi.updateStatusText(startCounter);
        InvokeRepeating("decreaseCounter", 0, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    // Decrease counter
    private void decreaseCounter()
    {
        startingPhaseUi.updateStatusText(startCounter);

        if (startCounter == 0)
        {
            startingPhaseUi.hide(true);
            gameplayUi.show();
        
            questionManager.selectQuestion();    
            playerController.InputEnabled = true;
            enemyController.startMovingAssignedCar();
        }


        if (startCounter < -1)
        {
            CancelInvoke("decreaseCounter");
        }
        
        startCounter--;
    }


}
