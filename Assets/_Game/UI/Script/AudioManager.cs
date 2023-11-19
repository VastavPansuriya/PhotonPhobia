using Vastav.Enums;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }



    [Header("SoundEffect Settings")]
    [SerializeField] private AudioSource sound_AudioSource;
    [SerializeField] private SoundData<SoundType>[] sounds_SFX_Data;

    [Header("SoundEffect Music")]
    [SerializeField] private AudioSource music_AudioSource;
    [SerializeField] private SoundData<MusicType>[] sounds_Music_Data;


    private void Awake()
    {
        InitInstance();
        ChangeBGMusic(MusicType.GameMusic);
    }

    private void InitInstance()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffect(SoundType type)
    {
        AudioClip clip = GetSoundClip(type);
        if (clip != null)
        {
            sound_AudioSource.PlayOneShot(clip);
        }
    }

    public void ChangeBGMusic(MusicType music)
    {
        AudioClip clip = GetSoundMusic(music);
        if (clip != null)
        {
            sound_AudioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetSoundClip(SoundType type)
    {
        SoundData<SoundType> whichSound = Array.Find(sounds_SFX_Data, i => i.effectType == type);

        if (whichSound != null)
        {
            return whichSound.effectClip;
        }
        return null;
    }

    private AudioClip GetSoundMusic(MusicType type)
    {
        SoundData<MusicType> whichSound = Array.Find(sounds_Music_Data, i => i.effectType == type);

        if (whichSound != null)
        {
            return whichSound.effectClip;
        }
        return null;
    }

    public void MuteToggle(bool isMute)
    {
        music_AudioSource.enabled = isMute;
        sound_AudioSource.enabled = isMute;
    }
}
