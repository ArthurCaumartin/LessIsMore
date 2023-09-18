using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        RockDestroy rockDestroy = other.GetComponent<RockDestroy>();
        if(rockDestroy)
        {
            rockDestroy.DoDestroy();
            GameManager.intance.InitialiseGameLevel();
            Destroy(gameObject);
        }
    }
}
