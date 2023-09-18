using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetContainer : MonoBehaviour
{
    [SerializeField] List<GameObject> targetList;

    public void RemoveTarget(GameObject toRemove)
    {
        targetList.Remove(toRemove);

        if(targetList.Count == 0)
            TargetManager.instance.SpawnTarget();
    }
}
