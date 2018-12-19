using UnityEngine;
using System.Collections;
using System;

public class GameplayUi : MonoBehaviour, IGameHud
{
    private void Start()
    {
        hide();   
    }

    public void hide()
    {
        transform.localScale = Vector3.zero;
    }

    public void show()
    {
        transform.localScale = Vector3.one;
    }
}