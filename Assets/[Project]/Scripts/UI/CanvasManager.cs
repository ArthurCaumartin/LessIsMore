using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("In Game :")]
    [SerializeField] TextMeshProUGUI timerTexte;

    // [Header("Menu :")]
    // [SerializeField] Canvas 

    void Awake()
    {
        instance = this;
    }

    public void RefreshTimer(float timer)
    {
        timerTexte.text = "Time left : " + timer.ToString();
    }
}
