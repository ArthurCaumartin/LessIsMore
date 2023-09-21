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
        CanvasManager.instance.ResetUI();//* a jouer aprés remove animation

        //! Menu
        physicsUiObject.SetActive(false);
    }

    public void ActiveMenu()
    {
        projectileManager.SpawnNewProjectile();

        print("Currrent Target = " + TargetManager.instance.HasCurrentBuilding());
        if(TargetManager.instance.HasCurrentBuilding())
        {
            print("Remove current Build !");
            TargetManager.instance.RemoveCurrentBuidingAnimation(() => 
            {
                physicsUiObject.SetActive(true);
            });
        }
        else
        {
            print("Just turn On PhUI!");
            physicsUiObject.SetActive(true);
        }
    }

    [ContextMenu("InitialiseGameLevel")]
    public void StartGameLevel()
    {
        CanvasManager.instance.SetInGameUI();

        backgroundColor.BackgroundTransition(1.5f, () =>
        {
            TargetManager.instance.SpawnNewBuilding();
            projectileManager.SpawnNewProjectile();
            levelTimer.StartTimer();
        });
    }

    public void RestartGame()
    {
        ClearGame();
        StartGameLevel();
    }

    [ContextMenu("EndGameLevel")]
    public void EndGameLevel()
    {
        projectileManager.DeleteProjectile();
        CanvasManager.instance.SetEndLevelPanel(score.GetScore());
    }

    public void BuildingClear(bool isBuilding)
    {
        if(isBuilding)
            score.AddBuildingScore();
        else
            score.AddTargetScore();
    }
}
