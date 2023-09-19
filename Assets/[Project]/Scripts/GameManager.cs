using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    [SerializeField] RockLauncher rockLauncher;
    [SerializeField] LevelTimer levelTimer;

    [Header("Score :")]
    [SerializeField] int currentScore;
    [SerializeField] int maxToAdd, minToAdd;

    [Header("Level Item :")]
    [SerializeField] GameObject targetPrefab;
    [SerializeField] Transform targetSpawn;
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform rockSpawn;

    void Awake()
    {
        intance = this;
    }

    void Start()
    {
        InitialiseGameLevel();
    }

    public void TargetHit()
    {
        ActualiseScore();
    }

    [ContextMenu("InitialiseGameLevel")]
    public void InitialiseGameLevel()
    {
        TargetManager.instance.SpawnTarget();
        SpawnNewRock();
        levelTimer.StartTimer();
    }

    public void SpawnNewRock()
    {
        GameObject newRock = Instantiate(rockPrefab, rockSpawn.position, Quaternion.identity);
        newRock.GetComponent<Rigidbody2D>().isKinematic = true;
        rockLauncher.SetCurrentRock(newRock);
    }

    void ActualiseScore()
    {
        currentScore += Random.Range(minToAdd, maxToAdd);
        CanvasManager.instance.RefreshScore(currentScore);
    }
}
