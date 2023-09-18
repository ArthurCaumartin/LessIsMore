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
        }
    }

    public void StartTimer()
    {
        currentTimer = startValue;
        isRunning = true;
    }

    public void StopTimer()
    {
        currentTimer = startValue;
        CanvasManager.instance.RefreshTimer(currentTimer);
        isRunning = false;
    }
}
