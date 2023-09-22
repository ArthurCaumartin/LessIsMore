using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] int currentScore;
    [SerializeField] int minToAddOnTargetHit, maxToAddOnTargetHit;
    [Space]
    [SerializeField] int minToAddOnBuilding, maxToAddOnBuilding;
    [Header("Ghost Score Text :")]
    [SerializeField] Transform scoreTextTransform;
    [SerializeField] GameObject ghostTextPrefab;

    public int GetScore()
    {
        return currentScore;
    }

    public void AddTargetScore()
    {
        int scoreToAdd = Random.Range(minToAddOnTargetHit, maxToAddOnTargetHit);
        currentScore += scoreToAdd;
        CanvasManager.instance.RefreshScore(currentScore);
        SpawnGhostScore(scoreToAdd);
    }

    public void AddBuildingScore()
    {
        int scoreToAdd = Random.Range(minToAddOnBuilding, maxToAddOnBuilding);
        currentScore += scoreToAdd;
        CanvasManager.instance.RefreshScore(currentScore);
        SpawnGhostScore(scoreToAdd);
    }

    public void ResetScore()
    {
        currentScore = 0;
        CanvasManager.instance.RefreshScore(currentScore);
    }

    void SpawnGhostScore(int scoreValue)
    {
        GameObject newGhost = Instantiate(ghostTextPrefab, scoreTextTransform);
        RectTransform ghostRect = (RectTransform)newGhost.transform;
        RectTransform scoreRectTransform = (RectTransform)scoreTextTransform;

        ghostRect.anchoredPosition = scoreRectTransform.anchoredPosition;
        ghostRect.position = scoreRectTransform.position;

        newGhost.GetComponent<TextMeshProUGUI>().text = "+ " + scoreValue.ToString() + "$";
    }
}
