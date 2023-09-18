using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public bool targetHit;
    public void DoDestroy()
    {
        if(!targetHit)
        {
            GameObject newParticle = Instantiate(particle.gameObject, transform.position, Quaternion.identity);
            Destroy(newParticle.gameObject, particle.main.duration);
        }
        GameManager.intance.SpawnNewRock();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DoDestroy();
    }
}
