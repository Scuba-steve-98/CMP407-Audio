using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    enum BIOME
    {
        VILLAGE,
        MOUNTAINS,
        PLAINS,
        FOREST,
        DUNGEON,
        DEFAULT
    }

    BIOME currentBiome;

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

    bool isDay = true;

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
        currentBiome = BIOME.MOUNTAINS;
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
        currentBiome = BIOME.DEFAULT;
        if (!isDay)
            return;

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
    }

    public void setMountains()
    {
        currentBiome = BIOME.MOUNTAINS;
        if (!isDay)
            return;

        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (dungeonSource.isPlaying)
            dungeonSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        mountiansSource.Play();
    }

    public void setVillage()
    {
        currentBiome = BIOME.VILLAGE;
        if (!isDay)
            return;

        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        villageSource.Play();
    }

    public void setDungeon()
    {
        currentBiome = BIOME.DUNGEON;
        if (!isDay)
            return;

        if (mountiansSource.isPlaying)
            mountiansSource.Stop();

        if (forestSource.isPlaying)
            forestSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        dungeonSource.Play();
    }

    public void setPlains()
    {
        currentBiome = BIOME.PLAINS;
        if (!isDay)
            return;

        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (nightimeSource.isPlaying)
            nightimeSource.Stop();

        plainsSource.Play();
    }

    public void setForest()
    {
        currentBiome = BIOME.FOREST;
        if (!isDay)
            return;

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

    public void setToDay(bool day)
    {
        isDay = day;
        if (isDay)
        {
            switch (currentBiome)
            {
                case BIOME.VILLAGE:
                    setVillage();
                    break;

                case BIOME.MOUNTAINS:
                    setMountains();
                    break;

                case BIOME.PLAINS:
                    setPlains();
                    break;

                case BIOME.FOREST:
                    setForest();
                    break;

                case BIOME.DUNGEON:
                    setDungeon();
                    break;

                case BIOME.DEFAULT:
                    setDefault();
                    break;
            }
        }
    }
}