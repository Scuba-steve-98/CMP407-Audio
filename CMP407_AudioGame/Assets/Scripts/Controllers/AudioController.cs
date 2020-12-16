using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioController : MonoBehaviour
{
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

        sounds.source.Play();
    }


    public void PlayOneShot(string name, float volume)
    {
        Sound sounds = Array.Find(audioClip, sound => sound.name == name);
        if (sounds == null)
        {
            Debug.LogWarning("Sound: " + name + " not found, please check spelling :P");
            return;
        }
        //sounds.source.Play();
        sounds.source.PlayOneShot(sounds.source.clip, volume);
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
}
