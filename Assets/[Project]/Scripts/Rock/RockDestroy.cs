using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public bool haveHitTarget;

    public void DoDestroy()
    {
        if(!haveHitTarget)
        {
            GameObject newParticle = Instantiate(particle.gameObject, transform.position, Quaternion.identity);
            Destroy(newParticle.gameObject, particle.main.duration);
        }
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MenuElement menuElement = other.GetComponent<MenuElement>();
        if(menuElement)
        {
            MenuManager.instance.SpawnMenuProjectile();
        }
        else
        {
            GameManager.intance.SpawnNewProjectile();
        }
        DoDestroy();
    }
}
