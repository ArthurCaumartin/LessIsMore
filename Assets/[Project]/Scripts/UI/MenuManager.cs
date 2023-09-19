using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform menuProjectileSpawn;
    [SerializeField] List<MenuElement> menuElementList;
    GameObject currentMenuProjectile;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        InitialiseMenu();
    }

    void InitialiseMenu()
    {
        gameObject.SetActive(true);
        ResetMenu();
    }

    public void ResetMenu()
    {
        if(currentMenuProjectile)
            Destroy(currentMenuProjectile);
        SpawnMenuProjectile();
        foreach (MenuElement item in menuElementList)
        {
            item.ResetElement();  
        }
    }

    public void SpawnMenuProjectile()
    {
        GameObject newProjectile = Instantiate(projectile, menuProjectileSpawn.position, Quaternion.identity);
        currentMenuProjectile = newProjectile;
    }
}
