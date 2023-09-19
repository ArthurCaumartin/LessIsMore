using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLife : MonoBehaviour
{
    [SerializeField] RockDestroy rockDestroy;
    [SerializeField] float lifeTime;
    public void StartLife()
    {
        StartCoroutine(Life());
    }

    IEnumerator Life()
    {
        yield return new WaitForSeconds(lifeTime);
        GameManager.intance.SpawnNewProjectile();
        rockDestroy.DoDestroy();
    }
}
