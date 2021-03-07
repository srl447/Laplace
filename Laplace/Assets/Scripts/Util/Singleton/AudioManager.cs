using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;
    public float sfxVolume = 1;
    public AudioClip bgm;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayOneShot(AudioClip clipToPlay)
    {
        audioSource.PlayOneShot(clipToPlay,sfxVolume);
    }

    public void ChangeBGM(AudioClip newBGM)
    {
        bgm = newBGM;
        audioSource.clip = bgm;
    }
}