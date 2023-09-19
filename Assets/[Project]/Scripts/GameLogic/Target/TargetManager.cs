using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;
    [SerializeField] List<GameObject> targetComponentPrefab;
    GameObject currentTarget;

    void Awake()
    {
        instance = this;
    }

    public void SpawnTarget()
    {
        if(currentTarget)
            Destroy(currentTarget);
            
        GameObject toSpawn = targetComponentPrefab[Random.Range(0, targetComponentPrefab.Count)];
        currentTarget = Instantiate(toSpawn, transform.position, Quaternion.identity);
    }
}
