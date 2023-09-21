using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] AudioSource audioSource;

    void Awake()
    {
        instance = this;    
    }

    public void PlaySF(AudioClip clipToPlay)
    {
        audioSource.PlayOneShot(clipToPlay);
    }
}
