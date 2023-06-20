using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] music;
    public Sound[] soundEffects;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(this);
            return;
        }

        DontDestroyOnLoad(this);

        foreach (Sound s in music)
            configureSound(s);

        foreach (Sound s in soundEffects)
            configureSound(s);
    }

    void Start()
    {
        Play("Theme");
    }


    public void Play(string name)
    {
        Sound s = Array.Find(music, Sound => Sound.name == name);
        if (s == null)
            s = Array.Find(soundEffects, Sound => Sound.name == name);
        if (s == null)
            Debug.LogWarning("Sound: '" +  name + "' not found!");
            return;
        s.source.Play();
    }

    private void configureSound(Sound s)
    {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
    }
}
