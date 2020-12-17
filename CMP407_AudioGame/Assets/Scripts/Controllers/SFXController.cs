using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    public AudioMixerGroup bookGroup;
    public AudioMixerGroup birdGroup;
    public AudioMixerGroup cricketGroup;

    public Sound[] books;
    public Sound[] birds;
    public Sound[] crickets;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Sound sound in books)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.outputAudioMixerGroup = bookGroup;
            sound.source.volume = sound.volume;
            sound.source.loop = sound.loop;
        }

        foreach (Sound sounds in birds)
        {

            sounds.source = gameObject.AddComponent<AudioSource>();
            sounds.source.clip = sounds.clip;
            sounds.source.outputAudioMixerGroup = birdGroup;
            sounds.source.volume = sounds.volume;
            sounds.source.loop = sounds.loop;
            sounds.source.spatialBlend = 1;
            sounds.source.maxDistance = 15;
            sounds.source.minDistance = 2;
            sounds.source.spatialize = true;
        }

        foreach (Sound sounds in crickets)
        {

            sounds.source = gameObject.AddComponent<AudioSource>();
            sounds.source.clip = sounds.clip;
            sounds.source.outputAudioMixerGroup = cricketGroup;
            sounds.source.volume = sounds.volume;
            sounds.source.loop = sounds.loop;
            sounds.source.spatialBlend = 1;
            sounds.source.maxDistance = 15;
            sounds.source.minDistance = 2;
            sounds.source.spatialize = true;
        }
    }

    public void PlayBook(string name)
    {
        Sound book = Array.Find(books, sound => sound.name == name);
        if (book == null)
        {
            Debug.LogWarning("Baaaka. Sound " + name + " disnae exist");
            return;
        }
        book.source.Play();
    }

    public void PlayBird(string name, Vector3 pos)
    {
        Sound bird = Array.Find(birds, sound => sound.name == name);
        if (bird == null)
        {
            Debug.LogWarning("Baaaka. Sound " + name + " disnae exist");
            return;
        }
        bird.source.gameObject.transform.position = pos;
        bird.source.Play();
    }

    public void PlayCricket(string name, Vector3 pos)
    {
        Sound cricket = Array.Find(crickets, sound => sound.name == name);
        if (cricket == null)
        {
            Debug.LogWarning("Baaaka. Sound " + name + " disnae exist");
            return;
        }
        cricket.source.gameObject.transform.position = pos;
        cricket.source.Play();
    }
}
