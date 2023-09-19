using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    GameObject currentMenuProjectile;
    [SerializeField] List<MenuElement> menuElementsList;

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        foreach (MenuElement item in menuElementsList)
        {
            item.ResetElement();
        }
    }

    public void SetSettingsUI()
    {

    }
}
