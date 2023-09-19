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

    [Header("Level Object :")]
    [SerializeField] GameObject targetPrefab;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform inGameProjectileSpawn;

    void Awake()
    {
        intance = this;
    }

    void Start()
    {
        // InitialiseGameLevel();
    }

    public void TargetHit()
    {
        ActualiseScore();
    }

    [ContextMenu("InitialiseGameLevel")]
    public void InitialiseGameLevel()
    {
        TargetManager.instance.SpawnTarget();
        SpawnNewProjectile();
        levelTimer.StartTimer();
    }

    public void SpawnNewProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab, inGameProjectileSpawn.position, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().isKinematic = true;
        rockLauncher.SetCurrentRock(newProjectile);
    }

    void ActualiseScore()
    {
        currentScore += Random.Range(minToAdd, maxToAdd);
        CanvasManager.instance.RefreshScore(currentScore);
    }

    public void EndLevel()
    {

    }
}
