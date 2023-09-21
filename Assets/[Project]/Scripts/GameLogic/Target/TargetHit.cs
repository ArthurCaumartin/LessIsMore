using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System.Diagnostics.Tracing;

public class TargetHit : MonoBehaviour
{
    [SerializeField] Sprite brokenGlassSprite;
        
    void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileDestroy rockDestroy = other.GetComponent<ProjectileDestroy>();
        if(rockDestroy)
        {
            GameManager.intance.BuildingClear(false);
            DisableThisTarget();
        }
    }

    void DisableThisTarget()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().sprite = brokenGlassSprite;
        GetComponentInParent<TargetContainer>().RemoveTarget(gameObject);
    }
}
