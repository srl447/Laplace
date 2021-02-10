﻿using System.Collections;
using System.Collections.Generic;
using Patterns;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;
    public int sfxVolume = 1;
    public AudioClip bgm;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = bgm;
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