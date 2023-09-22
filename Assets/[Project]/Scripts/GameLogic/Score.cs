using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System.Threading;
using Unity.VisualScripting;

public class Score : MonoBehaviour
{
    [SerializeField] int currentScore;
    [SerializeField] int minToAddOnTargetHit, maxToAddOnTargetHit;
    [Space]
    [SerializeField] int minToAddOnBuilding, maxToAddOnBuilding;

    [Header("Score To Add In Time")]
    [SerializeField] float delay;
    [SerializeField] List<int> scoreToAddList;
    float timer;

    [Header("Ghost Score Text :")]
    [SerializeField] Transform scoreTextTransform;
    [SerializeField] GameObject ghostTextPrefab;

    void Update()
    {
        timer += Time.deltaTime;
        if(scoreToAddList.Count > 0)
        {
            if(timer >= delay)
            {
                print("Spawn ghost Score !");
                timer = 0f;
                SpawnGhostScore(scoreToAddList[0]);
                AddCurrentScore(scoreToAddList[0]);
                scoreToAddList.Remove(scoreToAddList[0]);
            }
        }
    }

    public int GetScore()
    {
        return currentScore;
    }

    void AddCurrentScore(int value)
    {
        currentScore += value;
        CanvasManager.instance.RefreshScore(currentScore);
    }

    public void AddTargetScore()
    {
        print("Add target score !");
        int scoreValueToAdd = Random.Range(minToAddOnTargetHit, maxToAddOnTargetHit);
        scoreToAddList.Add(scoreValueToAdd);
        print("toAddList count = " + scoreToAddList.Count);
    }

    public void AddBuildingScore()
    {
        print("Add buildong score !");
        int scoreValueToAdd = Random.Range(minToAddOnBuilding, maxToAddOnBuilding);
        scoreToAddList.Add(scoreValueToAdd);
        print("toAddList count = " + scoreToAddList.Count);
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
