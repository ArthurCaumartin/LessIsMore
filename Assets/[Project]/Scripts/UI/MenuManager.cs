using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject settingMenu;
    [Header("Physics UI Element :")]
    [SerializeField] MenuElement startButton;
    [SerializeField] MenuElement settingsButton;
    [Space]
    [SerializeField] MenuElement backButton;
    [SerializeField] List<MenuElement> menuElementList;

    void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        ResetElement();
    }

    public void PlayMenuElementAnimation()
    {
        foreach (MenuElement item in menuElementList)
        {
            print(item.transform.parent.gameObject.name);
            if(item.transform.parent.gameObject.activeSelf)
                item.RemoveAnimation();
        }
    }

#region Call by MenuElement Events
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
#endregion

    void ResetElement()
    {
        foreach (MenuElement item in menuElementList)
        {
            item.ResetElement();
        }
    }
}
