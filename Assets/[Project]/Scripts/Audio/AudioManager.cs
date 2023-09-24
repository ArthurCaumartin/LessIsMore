using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource audioSourceFX;
    [SerializeField] AudioSource audioSourceMusic;

    void Awake()
    {
        instance = this;    
    }

    //! Call by Volume Slider events
    public void SetFXVolume(float value)
    {
        audioSourceFX.volume = value;
    }

    //! Call by Volume Slider events
    public void SetMusicVolume(float value)
    {
        audioSourceMusic.volume = value;
    }

    public void PlaySF(AudioClip clipToPlay)
    {
        audioSourceFX.PlayOneShot(clipToPlay);
    }
}
