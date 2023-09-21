using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;
    [SerializeField] float animationSpeed;
    [SerializeField] AnimationCurve curve;
    [SerializeField] Transform targetSpawnPoint;
    [SerializeField] Transform targetRemovePoint;
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
        currentTarget = Instantiate(toSpawn, targetSpawnPoint.position, Quaternion.identity, transform);
        
        //! Spawn animation
        currentTarget.transform.DOMove(transform.position, animationSpeed)
        .SetEase(curve);
    }

    [ContextMenu("RemoveTarget")]
    public void RemoveBuilding(Transform containerTransform)
    {
        GameManager.intance.TargetGetHit(true);

        containerTransform.transform.DOMove(targetRemovePoint.position, animationSpeed)
        .SetEase(curve)
        .OnComplete(() =>
        {
            Destroy(containerTransform.gameObject);
            SpawnTarget();
        });
    }

    public void AllTargetDerstroy(Transform targetContainer)
    {
        RemoveBuilding(targetContainer);
    }
}
