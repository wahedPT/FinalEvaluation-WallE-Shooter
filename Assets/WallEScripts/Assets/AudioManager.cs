using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
        //singleton 
    public static AudioManager instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        foreach (Sound item in sounds)
        {
            item.audioSource = gameObject.AddComponent<AudioSource>();
            item.audioSource.clip = item.audioClip;
            item.audioSource.volume = item.volume;
            item.audioSource.pitch = item.pitch;
            item.audioSource.loop = item.loop;
        }
    }
    private void Start()
    {
        PlayAudio("BackGround");
    }
    public void PlayAudio(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);

        if (s == null)
        {
            Debug.LogWarning("Hey AudioName " + name + " not found");
            return;
        }
        s.audioSource.Play();

    }
    public void StopPlayAudio(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Hey AudioName " + name + " not found");
            return;
        }
        s.audioSource.Stop();

    }

    public void SetVolume(string name, float VolumeVal)
    {
        Sound s = Array.Find(sounds, Sound => Sound.audioName == name);
        if (s == null)
        {
            Debug.LogWarning("Hey AudioName " + name + " not found");
            return;
        }
        else
        {
            s.audioSource.volume = VolumeVal;
        }
    }
}
