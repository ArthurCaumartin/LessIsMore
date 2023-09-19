using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float startValue;
    bool isRunning;
    float currentTimer;

    void Update()
    {
        if(isRunning)
        {
            currentTimer -= Time.deltaTime;
            CanvasManager.instance.RefreshTimer(currentTimer);
            if(currentTimer <= 0)
            {
                StopTimer();
                GameManager.intance.EndLevel();
            }
        }
    }

    public void StartTimer()
    {
        currentTimer = startValue;
        isRunning = true;
    }

    public void StopTimer()
    {
        currentTimer = 0f;
        CanvasManager.instance.RefreshTimer(currentTimer);
        isRunning = false;
    }
}
