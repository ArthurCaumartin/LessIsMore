using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] RockLauncher rockLauncher;
    [Header("Rock parameter :")]
    [SerializeField] GameObject rockPrefab;
    [SerializeField] Transform rockSpawn;

    void Start()
    {
        InitialiseGameLevel();
    }

    void InitialiseGameLevel()
    {
        GameObject newRock = Instantiate(rockPrefab, rockSpawn.position, Quaternion.identity);
        newRock.GetComponent<Rigidbody2D>().isKinematic = true;
        rockLauncher.SetCurrentRock(newRock);
    }
}
