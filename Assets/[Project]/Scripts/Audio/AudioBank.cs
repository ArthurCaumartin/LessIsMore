using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBank : MonoBehaviour
{
    public static AudioBank instance;
    [SerializeField] ScriptableAudioBank scriptableAudioBank;
    public static AudioClip rockHit1;
    public static AudioClip rockHit2;
    [Space]
    [SerializeField] List<AudioClip> glassBreakList;

    void Awake()
    {
        instance = this;
    }

    public AudioClip GetRandomGlassBreak()
    {
        return glassBreakList[Random.Range(0,glassBreakList.Count)];
    }
}
