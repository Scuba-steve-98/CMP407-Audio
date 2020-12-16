using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    bool isNearDungeon = false;
    bool isNearMountains = false;
    bool isNearForest = false;
    bool isNearVillage = false;
    bool isNearPlains = false;
    //bool isOnWater = false;
    bool yes = false;

    public AudioMixerGroup _audioMixer;

    public AudioClip defaultMusic;
    public AudioClip village;
    public AudioClip mountians;
    public AudioClip plains;
    public AudioClip forest;
    public AudioClip nightime;
    public AudioClip dungeon;

    AudioSource defaultMusicSource;
    AudioSource villageSource;
    AudioSource mountiansSource;
    AudioSource plainsSource;
    AudioSource forestSource;
    AudioSource nightimeSource;
    AudioSource dungeonSource;


    // Start is called before the first frame update
    void Start()
    {
        defaultMusicSource = gameObject.AddComponent<AudioSource>();
        defaultMusicSource.clip = defaultMusic;
        defaultMusicSource.loop = true;
        defaultMusicSource.volume = 0.5f;
        defaultMusicSource.outputAudioMixerGroup = _audioMixer;

        villageSource = gameObject.AddComponent<AudioSource>();
        villageSource.clip = village;
        villageSource.loop = true;
        villageSource.volume = 0.5f;
        villageSource.outputAudioMixerGroup = _audioMixer;

        mountiansSource = gameObject.AddComponent<AudioSource>();
        mountiansSource.clip = mountians;
        mountiansSource.loop = true;
        mountiansSource.volume = 0.5f;
        mountiansSource.outputAudioMixerGroup = _audioMixer;

        plainsSource = gameObject.AddComponent<AudioSource>();
        plainsSource.clip = plains;
        plainsSource.loop = true;
        plainsSource.volume = 0.5f;
        plainsSource.outputAudioMixerGroup = _audioMixer;

        forestSource = gameObject.AddComponent<AudioSource>();
        forestSource.clip = forest;
        forestSource.loop = true;
        forestSource.volume = 0.5f;
        forestSource.outputAudioMixerGroup = _audioMixer;

        nightimeSource = gameObject.AddComponent<AudioSource>();
        nightimeSource.clip = nightime;
        nightimeSource.loop = true;
        nightimeSource.volume = 0.5f;
        nightimeSource.outputAudioMixerGroup = _audioMixer;

        dungeonSource = gameObject.AddComponent<AudioSource>();
        dungeonSource.clip = dungeon;
        dungeonSource.loop = true;
        dungeonSource.volume = 0.5f;
        dungeonSource.outputAudioMixerGroup = _audioMixer;

        mountiansSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(mountiansSource.isPlaying);
        if (Input.GetKeyDown(KeyCode.Space) && !yes)
        {
            yes = true;
            Debug.Log(mountiansSource.isPlaying);
            stopMountains();
            //mountiansSource.Stop();
            Debug.Log("Yeet");
        }
    }

    public void updateMusicVolume(float lerpValue)
    {
        if (lerpValue > 0)
        {
            defaultMusicSource.volume = lerpValue / 1.3333f;
            villageSource.volume = lerpValue / 1.3333f;
            mountiansSource.volume = lerpValue / 1.3333f;
            plainsSource.volume = lerpValue / 1.3333f;
            forestSource.volume = lerpValue / 1.3333f;
            nightimeSource.volume = lerpValue / 1.3333f;
            dungeonSource.volume = lerpValue / 1.3333f;
        }
    }


    public void setDefault()
    {
        if (villageSource.isPlaying)
            villageSource.Stop();

        if (mountiansSource.isPlaying)
            mountiansSource.Stop();

        if (plainsSource.isPlaying)
            plainsSource.Stop();

        if (forestSource.isPlaying)
            forestSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        defaultMusicSource.Play();
        Debug.Log("EEEEEE");
    }

    public void setMountains()
    {
        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (dungeonSource.isPlaying)
            dungeonSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        mountiansSource.Play();
        Debug.Log("EEEEEE");
    }

    public void setVillage()
    {
        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        villageSource.Play();
    }

    public void stopMountains()
    {
        if (mountiansSource.isPlaying)
        {
            Debug.Log(mountiansSource.isPlaying);
            mountiansSource.Stop();
            Debug.Log(mountiansSource.isPlaying);
        }
        Debug.Log(mountiansSource.isPlaying + "???????");
    }

    public void setDungeon()
    {
        //if (mountiansSource.isPlaying)
        //    mountiansSource.Stop();

        //if (forestSource.isPlaying)
        //    forestSource.Stop();

        //if (nightimeSource.isPlaying)
        //    nightimeSource.Stop();

        dungeonSource.Play();

        Debug.Log("Nani");
    }

    public void setPlains()
    {
        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        plainsSource.Play();
    }

    public void setForest()
    {
        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (dungeonSource.isPlaying)
            dungeonSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        forestSource.Play();
    }

    public void setNight()
    {
        if (villageSource.isPlaying)
            villageSource.Stop();

        if (mountiansSource.isPlaying)
            mountiansSource.Stop();

        if (plainsSource.isPlaying)
            plainsSource.Stop();

        if (forestSource.isPlaying)
            forestSource.Stop();

        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (dungeonSource.isPlaying)
            dungeonSource.Stop();

        nightimeSource.Play();
    }

    public void setNearForest(bool near)
    {
        isNearForest = near;
        Debug.Log("Forest" + near);
    }

    public void setNearMountains(bool near)
    {
        isNearMountains = near;
        Debug.Log("Mountains" + near);
    }

    public void setNearPlains(bool near)
    {
        isNearPlains = near;
        Debug.Log("Plains" + near);
    }

    public void setNearVillage(bool near)
    {
        isNearVillage = near;
        Debug.Log("Village" + near);
    }



    //defaultMusicSource
    //villageSource
    //mountiansSource
    //plainsSource
    //forestSource
    //nightimeSource
    //dungeonSource
}
