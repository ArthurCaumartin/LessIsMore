using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    [SerializeField] RockLauncher rockLauncher;
    [SerializeField] LevelTimer levelTimer;
    [SerializeField] TargetManager targetManager;
        
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
        SpawnNewRock();
    }

    public void InitialiseGameLevel()
    {
        targetManager.SpawnTarget();
        SpawnNewRock();
        levelTimer.StartTimer();
    }

    void SpawnTarget()
    {
        GameObject newTarget = Instantiate(targetPrefab, targetSpawn.position, Quaternion.identity);
    }

    public void SpawnNewRock()
    {
        GameObject newRock = Instantiate(rockPrefab, rockSpawn.position, Quaternion.identity);
        newRock.GetComponent<Rigidbody2D>().isKinematic = true;
        rockLauncher.SetCurrentRock(newRock);
    }
}
