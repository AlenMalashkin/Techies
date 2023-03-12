using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SoundInvoker : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource soundEffectSource;
    
    private float _musicVolume = 0.5f;
    private float _soundEffectVolume = 0.5f;

    public float MusicVolume => _musicVolume;
    public float SoundEffectVolume => _soundEffectVolume;
    
    private static SoundInvoker _instance;
    public static SoundInvoker Instance => _instance;

    
    
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusicClip(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.volume = _musicVolume;
        musicSource.loop = true;
    }

    public void ChangeMusicVolume(float volume)
    {
        _musicVolume = volume;
        musicSource.volume = _musicVolume;
    }

    public void PlaySoundEffectClip(AudioClip clip)
    {
        soundEffectSource.clip = clip;
        soundEffectSource.volume = _soundEffectVolume;
    }

    public void ChangeSoundEffectVolume(float volume)
    {
        _soundEffectVolume = volume;
        soundEffectSource.volume = _soundEffectVolume;
    }
}
