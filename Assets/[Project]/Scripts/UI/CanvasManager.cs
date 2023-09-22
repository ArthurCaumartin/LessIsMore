using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("In Game :")]
    [SerializeField] GameObject inGameCanvasObject;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI scoreValueText;

    [Header("End Level Panel :")]
    [SerializeField] RectTransform endLevelPanelTransform;
    [SerializeField] TextMeshProUGUI panelScroreText;

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

        timerText.text = "Time left : " + seconds + "." + millSeconds;
    }

    public void RefreshScore(int score)
    {
        scoreValueText.text = score.ToString() + "$";
    }

    public void SetEndLevelPanel(int score)
    {
        endLevelPanelTransform.gameObject.SetActive(true);
        endLevelPanelTransform.eulerAngles = new Vector3(0, 0, Random.Range(-20f, 20f));

        panelScroreText.text = score.ToString() + " $";
    }

    public void SetInGameUI()
    {
        inGameCanvasObject.SetActive(true);
    }

    public void ResetUI()
    {
        inGameCanvasObject.SetActive(false);
        endLevelPanelTransform.gameObject.SetActive(false);
    }
}
