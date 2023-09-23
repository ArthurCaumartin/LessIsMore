using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;
    [SerializeField] float animationDuration;
    [SerializeField] AnimationCurve curve;
    [SerializeField] Transform targetSpawnPoint;
    [SerializeField] Transform targetRemovePoint;
    [SerializeField] List<GameObject> targetComponentPrefab;
    GameObject currentBuilding;

    void Awake()
    {
        instance = this;
    }

    public void SpawnNewBuilding()
    {
        if(currentBuilding)
            Destroy(currentBuilding);
        
        GameObject toSpawn = targetComponentPrefab[UnityEngine.Random.Range(0, targetComponentPrefab.Count)];
        currentBuilding = Instantiate(toSpawn, targetSpawnPoint.position, Quaternion.identity, transform);
        
        //! Spawn animation
        currentBuilding.transform.DOMove(transform.position, animationDuration)
        .SetEase(curve);
    }

    [ContextMenu("RemoveTarget")]
    public void RemoveBuildingAllTargetClear(Transform containerTransform)
    {
        currentBuilding = null;
        GameManager.intance.AddScore(true);

        containerTransform.transform.DOMove(targetRemovePoint.position, animationDuration)
        .SetEase(curve)
        .OnComplete(() =>
        {
            Destroy(containerTransform.gameObject);
            SpawnNewBuilding();
        });
    }

    public void AllTargetDerstroy(Transform targetContainer)
    {
        RemoveBuildingAllTargetClear(targetContainer);
    }

    public bool HasCurrentBuilding()
    {
        return currentBuilding;
    }

    public void RemoveCurrentBuidingAnimation(Action onComplet)
    {
        if(!currentBuilding)
            return;

        currentBuilding.transform.DOMove(targetRemovePoint.position, animationDuration)
        .SetEase(curve)
        .OnComplete(() =>
        {
            Destroy(currentBuilding);
            onComplet();
        });
    }
}
