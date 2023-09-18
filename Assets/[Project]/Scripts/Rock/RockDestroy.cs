using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDestroy : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;
    public IEnumerator DoDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject newParticle = Instantiate(particle.gameObject, transform.position, Quaternion.identity);
        Destroy(newParticle.gameObject, particle.main.duration);
        Destroy(gameObject);
    }
}
