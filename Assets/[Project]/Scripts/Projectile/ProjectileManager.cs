using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;
    [SerializeField] ProjectileLauncher launcher;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform inGameTransform;
    [SerializeField] Transform menuSpawnPoint;

    GameObject currentProjectile;

    void Awake()
    {
        instance = this;
    }

    public void SpawnNewProjectile(GameObject caller)
    {
        print("Spawn proj by : " + caller.name);

        Vector2 spawnPoint = GetSpawnPoint();
        GameObject newProjectile = Instantiate(projectilePrefab, spawnPoint, Quaternion.identity);
        newProjectile.GetComponent<Rigidbody2D>().isKinematic = true;
        launcher.SetCurrentProjectile(newProjectile);

        currentProjectile = newProjectile;
    }

    public void DeleteProjectile()
    {
        if(currentProjectile)
            Destroy(currentProjectile);
    }

    Vector3 GetSpawnPoint()
    {
        State gameState = GameState.instance.GetGameState();

        switch (gameState)
        {
            case State.Menu :
                return menuSpawnPoint.position;

            case State.InGame :
                return inGameTransform.position;

            default :
                return menuSpawnPoint.position;
        }
    }
}
