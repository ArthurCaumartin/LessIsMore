using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("In Game :")]
    [SerializeField] TextMeshProUGUI timerTexte;
    [SerializeField] TextMeshProUGUI scoreTexte;

    [Header("End Level :")]
    [SerializeField] GameObject endLevelPanel;

    void Awake()
    {
        instance = this;
    }

    public void RefreshTimer(float timer)
    {
        string[] timerString = timer.ToString().Split(",");
        string seconds = timerString[0];
        char millSeconds = ' ';
        if(timerString.Length > 1)
            millSeconds = timerString[1].ToCharArray()[0];

        timerTexte.text = "Time left : " + seconds + "." + millSeconds;
    }

    public void RefreshScore(int score)
    {
        scoreTexte.text = "Money Waist : " + score.ToString() + "$";
    }

    public void SetEndLevelPanel()
    {

    }
}
