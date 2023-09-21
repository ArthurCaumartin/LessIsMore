using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public static GameSettings instance;

    [Header("Sound Volume : ")]
    [Range(0, 1)] public float musicVolume;
    [Range(0, 1)] public float fxVolume;

    void Awake()
    {
        instance = this;
    }

    public void SetFxVolume(float volumeToSet)
    {
        fxVolume = volumeToSet;
    }
}
