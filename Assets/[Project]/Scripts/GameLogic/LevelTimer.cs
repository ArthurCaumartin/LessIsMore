using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] BackgroundColor backgroundTimer;
    [SerializeField] float startTimer;
    bool isRunning;
    float currentTimer;

    void Update()
    {
        if(isRunning)
        {
            currentTimer -= Time.deltaTime;
            CanvasManager.instance.RefreshTimer(currentTimer);
            backgroundTimer.SetBackgroundTimerColor(Mathf.InverseLerp(0, startTimer, currentTimer));
            if(currentTimer <= 0)
            {
                StopTimer();
            }
        }
    }

    public void StartTimer()
    {
        currentTimer = startTimer;
        isRunning = true;
    }

    public void StopTimer()
    {
        currentTimer = 0f;
        CanvasManager.instance.RefreshTimer(currentTimer);
        isRunning = false;
    }
}
