using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System.Diagnostics.Tracing;

public class TargetHit : MonoBehaviour
{
    [SerializeField] Sprite brokenGlassSprite;
    [SerializeField] ParticleSystem glassParticlSysteme;
        
    void OnTriggerEnter2D(Collider2D other)
    {
        ProjectileDestroy rockDestroy = other.GetComponent<ProjectileDestroy>();
        if(rockDestroy)
        {
            GameManager.intance.AddScore(false);
            AudioManager.instance.PlaySF(AudioBank.instance.GetRandomGlassBreak());
            DisableThisTarget();
        }
    }

    void DisableThisTarget()
    {
        GetComponent<Collider2D>().enabled = false;
        GetComponentInChildren<SpriteRenderer>().sprite = brokenGlassSprite;
        GetComponentInParent<TargetContainer>().RemoveTarget(gameObject);

        GameObject newGlassPrticle = Instantiate(glassParticlSysteme.gameObject, transform.position, Quaternion.identity);
        Destroy(newGlassPrticle, glassParticlSysteme.main.duration);
    }
}
