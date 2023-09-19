using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject settingMenu;
    [SerializeField] List<MenuElement> menuElementsList;

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        ResetElement();
    }

    public void SetStartUI()
    {
        ResetElement();
        startMenu.SetActive(true);
        settingMenu.SetActive(false);
    }

    public void SetSettingsUI()
    {
        ResetElement();
        startMenu.SetActive(false);
        settingMenu.SetActive(true);
    }

    void ResetElement()
    {
        foreach (MenuElement item in menuElementsList)
        {
            item.ResetElement();
        }
    }
}
