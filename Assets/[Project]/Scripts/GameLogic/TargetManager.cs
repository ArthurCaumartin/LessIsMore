using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetManager : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab;
    [SerializeField] List<Transform> targetPositionnList;

    public void SpawnTarget()
    {
        foreach(Transform item in targetPositionnList)
        {
            GameObject newTarget = Instantiate(targetPrefab, item.position, Quaternion.identity);
        }
    }

    public void RemoveTarget(Transform toRemove)
    {
        targetPositionnList.Remove(toRemove);
    }
}
