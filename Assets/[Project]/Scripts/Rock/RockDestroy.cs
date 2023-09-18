using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public void DoDestroy()
    {
        GameObject newParticle = Instantiate(particle.gameObject, transform.position, Quaternion.identity);
        Destroy(newParticle.gameObject, particle.main.duration);
        Destroy(gameObject);
    }
}
