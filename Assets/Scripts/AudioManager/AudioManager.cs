using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Public fields
    public static float masterVolume = 1.0f;
    public Sound[] sounds;
    public static AudioManager instance; // Singleton

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.playOnAwake = s.playOnAwake;
            s.source.loop = s.loop;
            s.source.volume = masterVolume;
        }
    }

    private void Update()
    {
        // Master volume for all sounds
        foreach (Sound s in sounds)
        {
            s.source.volume = masterVolume;
        }

        // Sound in game
        if (!ShowHideMenu.gameIsPaused && !ReturnAudioSource("GameLoop").isPlaying)
        {
            ReturnAudioSource("MenuLoop").Pause();
            Play("GameLoop");
        }
        // Sound in menu
        else if (ShowHideMenu.gameIsPaused && !ReturnAudioSource("MenuLoop").isPlaying)
        {
            ReturnAudioSource("GameLoop").Pause();
            Play("MenuLoop");
        }
    }

    // Play sound
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    // Play one shot sound
    public void PlayOneShot(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.PlayOneShot(s.clip);
    }

    // Retrieve sound
    public AudioSource ReturnAudioSource(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        return s.source;
    }
}
