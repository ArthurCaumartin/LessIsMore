using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    public void DoDestroy()
    {
        GameObject newParticle = Instantiate(particle.gameObject, transform.position, Quaternion.identity);
        Destroy(newParticle.gameObject, particle.main.duration);

        ProjectileManager.instance.SpawnNewProjectile(gameObject);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DoDestroy();
    }
}
