using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    [SerializeField] RockLauncher rockLauncher;
    [SerializeField] LevelTimer levelTimer;
        
    [Header("Level Item :")]
    [SerializeField] GameObject targetPrefab;
    [SerializeField] Transform targetSpawn;
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform rockSpawn;

    void Awake()
    {
        intance = this;
    }

    public void TargetHit()
    {
        SpawnNewRock();
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
}
