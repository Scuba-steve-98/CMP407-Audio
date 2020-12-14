using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    int audioPlayed = 0;
    bool isOnWater;
    // Start is called before the first frame update
    public AudioMixerGroup _audioMixer;

    public Sound[] audioClip;

    //public static AudioManager instance;

    void Awake()
    {
        foreach (Sound sounds in audioClip)
        {

            sounds.source = gameObject.AddComponent<AudioSource>();
            sounds.source.clip = sounds.clip;
            sounds.source.outputAudioMixerGroup = _audioMixer;

            sounds.source.volume = sounds.volume;
            sounds.source.loop = sounds.loop;
        }
    }

    public void Play(string name)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found, please check spelling :P");
            return;
        }
        audioPlayed++;
        //Debug.Log("Audio " + name + " played " + audioPlayed);
        sounds.source.Play();
    }


    public void PlayAtPoint(string name, float volume)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found, please check spelling :P");
            return;
        }
        sounds.source.volume = sounds.volume * volume;
        sounds.source.Play();
        //Debug.Log("Source Volume: " + sounds.source.volume);
    }


    public void Stop(string name)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            return;
        }
        if (sounds.source.isPlaying)
            sounds.source.Stop();
    }


    public bool IsPlaying(string name)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            return true;
        }
        return sounds.source.isPlaying;
    }


    public void UpdateVolume(string name, float volume)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found, please check spelling :P");
            return;
        }
        sounds.source.volume = sounds.volume * volume;
    }


    public void Pause(string name)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found, please check spelling :P");
            return;
        }
        sounds.source.Pause();
    }

    public void setInWater(bool water)
    {
        isOnWater = water;
        Debug.Log("water" + isOnWater);
    }

    public void updateDepthInWater(float water)
    {
        float depth = gameObject.transform.position.y - water;
        Debug.Log("Water: " + (gameObject.transform.position.y - 3.92f));
        Debug.Log("Depth: " + depth);
    }
}
