using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;


public class GameOverUi : MonoBehaviour
{
    [SerializeField]
    private Text titleText;

    private void Start()
    {
        hide();
    }


    public void hide()
    {
        transform.localScale = Vector3.zero;
    }

    public void show(bool playerOneWins)
    {
        if (playerOneWins)
            titleText.text = "You Win";
        else
            titleText.text = "You Lose";

        transform.localScale = Vector3.one;
    }
}