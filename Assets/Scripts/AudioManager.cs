using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    #region Singleton

    public static AudioManager Instance;

    #endregion

    [Header("Audio Settings")]
    [SerializeField] private Sound[] sounds;
    [SerializeField] private Sound[] themes;

    [Header("Instances")]
    [SerializeField] private AudioMixerGroup SFXGroup;
    [SerializeField] private AudioMixerGroup musicGroup;
    [SerializeField] private AudioMixer masterMixer;

    private void Awake()
    {
        Instance = this;

        foreach (Sound sound in sounds)
        {
            CreateSound(sound, SFXGroup);
        }

        foreach (Sound theme in themes)
        {
            CreateSound(theme, musicGroup);
        }
    }

    private void Start()
    {
        //themes[0].source.Play();
    }

    private Sound FindSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return null;
        }

        return s;
    }

    public void Play(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
            return;

        s.source.Play();
    }

    public void PlayOnce(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
            return;

        if (s.source.isPlaying)
            return;

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = FindSound(name);
        if (s == null)
            return;

        s.source.Stop();
    }

    private void CreateSound(Sound sound, AudioMixerGroup mixerGroup)
    {
        sound.source = gameObject.AddComponent<AudioSource>();
        sound.source.clip = sound.clip;
        sound.source.outputAudioMixerGroup = mixerGroup;

        sound.source.volume = sound.volume;
        sound.source.pitch = sound.pitch;
        sound.source.loop = sound.loop;
    }
}
