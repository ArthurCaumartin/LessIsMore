using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Score : MonoBehaviour
{
    [SerializeField] int currentScore;
    [SerializeField] int minToAddOnTargetHit, maxToAddOnTargetHit;
    [Space]
    [SerializeField] int minToAddOnBuilding, maxToAddOnBuilding;
    public int GetScore()
    {
        return currentScore;
    }

    public void AddTargetScore()
    {
        currentScore += Random.Range(minToAddOnTargetHit, maxToAddOnTargetHit);
        CanvasManager.instance.RefreshScore(currentScore);
    }

    public void AddBuildingScore()
    {
        currentScore += Random.Range(minToAddOnBuilding, maxToAddOnBuilding);
        CanvasManager.instance.RefreshScore(currentScore);
    }

    public void ResetScore()
    {
        currentScore = 0;
        CanvasManager.instance.RefreshScore(currentScore);
    }
}
