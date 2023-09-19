using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] Sprite brokenGlassSprite;
        
    void OnTriggerEnter2D(Collider2D other)
    {
        RockDestroy rockDestroy = other.GetComponent<RockDestroy>();
        if(rockDestroy)
        {
            print("Target Hit");
            rockDestroy.haveHitTarget = true;
            GameManager.intance.TargetHit();
            GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().sprite = brokenGlassSprite;
            GetComponentInParent<TargetContainer>().RemoveTarget(gameObject);
        }
    }
}
