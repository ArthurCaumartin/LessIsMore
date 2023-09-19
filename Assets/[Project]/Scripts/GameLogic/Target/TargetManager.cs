using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using DG.Tweening;

public class TargetManager : MonoBehaviour
{
    public static TargetManager instance;
    [SerializeField] float animationSpeed;
    [SerializeField] AnimationCurve curve;
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
        currentTarget = Instantiate(toSpawn, transform);
    }

    [ContextMenu("RemoveTarget")]
    void RemoveTarget()
    {
        currentTarget.transform.DOMove(targetRemovePoint.position, animationSpeed)
        .SetSpeedBased()
        .SetEase(curve);
    }
}
