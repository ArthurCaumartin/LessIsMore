using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Score : MonoBehaviour
{
    [SerializeField] int currentScore;
    [SerializeField] int minToAdd, maxToAdd;

    public int GetScore()
    {
        return currentScore;
    }

    public void AddScore()
    {
        currentScore += Random.Range(minToAdd, maxToAdd);
        CanvasManager.instance.RefreshScore(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        CanvasManager.instance.RefreshScore(currentScore);
    }
}
