using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    [SerializeField] LevelTimer levelTimer;
    [SerializeField] Score score;
    [SerializeField] ProjectileManager projectileManager;
    [SerializeField] BackgroundColor backgroundColor;

    [Header("Core GameObject :")]
    [SerializeField] GameObject physicsUiObject;
    [SerializeField] GameObject canvasObject;

    [Header("Level Object :")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform inGameProjectileSpawn;

    void Awake()
    {
        intance = this;
    }

    public void ClearGame()
    {
        print("Clear Game");

        ProjectileManager.instance.DeleteProjectile();

        //! In Game
        score.ResetScore();
        levelTimer.StopTimer();
        canvasObject.SetActive(false);

        //! Menu
        physicsUiObject.SetActive(false);
    }

    public void ActiveMenu()
    {
        physicsUiObject.SetActive(true);
        projectileManager.SpawnNewProjectile();
    }

    public void ActiveInGame()
    {
        canvasObject.SetActive(true);
        StartGameLevel();
    }

    [ContextMenu("InitialiseGameLevel")]
    public void StartGameLevel()
    {
        // backgroundColor.BackgroundTransition(1.5f, () =>
        // {
        //     TargetManager.instance.SpawnTarget();
        //     projectileManager.SpawnNewProjectile();
        //     levelTimer.StartTimer();
        // });

        TargetManager.instance.SpawnTarget();
        projectileManager.SpawnNewProjectile();
        levelTimer.StartTimer();
    }

    public void EndGameLevel()
    {
        
    }

    public void TargetHit()
    {
        score.AddScore();
    }
}
