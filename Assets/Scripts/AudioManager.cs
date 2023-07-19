using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

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
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in music)
            ConfigureSound(s);

        foreach (Sound s in soundEffects)
            ConfigureSound(s);

        SceneManager.sceneUnloaded += SceneUnloadedStopMusic;
        SceneManager.sceneLoaded += SceneLoadedStartMusic;
        GameEvents.instance.onBallHit += PlayBallHit;
    }

    void OnDestroy()
    {
        SceneManager.sceneUnloaded -= SceneUnloadedStopMusic;
        SceneManager.sceneLoaded -= SceneLoadedStartMusic;
        GameEvents.instance.onBallHit -= PlayBallHit;
    }

    void Start()
    {
        Play("MainMenu");
    }


    public void Play(string name)
    {
        Sound s = Array.Find(music, Sound => Sound.name == name);
        if (s == null)
            s = Array.Find(soundEffects, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: '" + name + "' not found!");
            return;
        }

        s.source.Play();
    }

    public void PlayBallHit()
    {
        List<string> ballHitSounds = new List<string>();

        foreach (Sound s in soundEffects)
            if (s.name.IndexOf("BallHit") != -1)
                ballHitSounds.Add(s.name);

        instance.Play(ballHitSounds[UnityEngine.Random.Range(0, ballHitSounds.Count)]);
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(music, Sound => Sound.name == name);
        if (s == null)
            s = Array.Find(soundEffects, Sound => Sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: '" + name + "' not found!");
            return;
        }

        s.source.Stop();
    }

    private void ConfigureSound(Sound s)
    {
        s.source = gameObject.AddComponent<AudioSource>();
        s.source.clip = s.clip;
        s.source.volume = s.volume;
        s.source.pitch = s.pitch;
        s.source.loop = s.loop;
    }

    public void SceneUnloadedStopMusic(Scene scene) { Stop(scene.name); }

    public void SceneLoadedStartMusic(Scene scene, LoadSceneMode mode) { Play(scene.name); }
}
