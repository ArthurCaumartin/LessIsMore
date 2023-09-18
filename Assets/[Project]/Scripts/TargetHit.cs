using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    [SerializeField] Sprite brokenGlass;
    void OnTriggerEnter2D(Collider2D other)
    {
        RockDestroy rockDestroy = other.GetComponent<RockDestroy>();
        if(rockDestroy)
        {
            rockDestroy.DoDestroy();
            GameManager.intance.TargetHit();
            GetComponent<Collider2D>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().sprite = brokenGlass;
        }
    }
}
