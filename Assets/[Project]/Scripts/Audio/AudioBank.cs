using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBank : MonoBehaviour
{
    [SerializeField] ScriptableAudioBank scriptableAudioBank;
    public static AudioClip rockHit1;
    public static AudioClip rockHit2;
    [Space]
    public static AudioClip glassBreak1;
    public static AudioClip glassBreak2;
    public static AudioClip glassBreak3;

    void InitialiseBank()
    {
        rockHit1 = scriptableAudioBank.rockHit1;
        rockHit2 = scriptableAudioBank.rockHit2;

        glassBreak1 = scriptableAudioBank.glassBreak1;
        glassBreak2 = scriptableAudioBank.glassBreak2;
        glassBreak3 = scriptableAudioBank.glassBreak3;
    }
}
