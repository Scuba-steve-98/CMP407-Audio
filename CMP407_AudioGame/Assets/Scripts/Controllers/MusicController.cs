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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Biome: " + currentBiome);
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("--------------------------------------");
            if (defaultMusicSource.isPlaying)
                Debug.Log("Default: " + defaultMusicSource.isPlaying);

            if (villageSource.isPlaying)
                Debug.Log("Village: " + villageSource.isPlaying);

            if (mountiansSource.isPlaying)
                Debug.Log("Mountains: " + mountiansSource.isPlaying);

            if (plainsSource.isPlaying)
                Debug.Log("Plains: " + plainsSource.isPlaying);

            if (forestSource.isPlaying)
                Debug.Log("Forest: " + forestSource.isPlaying);

            if (dungeonSource.isPlaying)
                Debug.Log("Dungeon: " + dungeonSource.isPlaying);

            if (nightimeSource.isPlaying)
                Debug.Log("Night: " + nightimeSource.isPlaying);
        }
    }

    public void setBiome(string biome)
    {
        if (biome == "Mount")
        {
            currentBiome = BIOME.MOUNTAINS;
        }
        if (biome == "Vill")
        {
            currentBiome = BIOME.VILLAGE;
        }
        if (biome == "Def")
        {
            currentBiome = BIOME.DEFAULT;
        }
        if (biome == "Plain")
        {
            currentBiome = BIOME.PLAINS;
        }
        if (biome == "For")
        {
            currentBiome = BIOME.FOREST;
        }
        if (biome == "Dun")
        {
            currentBiome = BIOME.DUNGEON;
        }
    }

    public void updateAllDayMusicVolume(float lerpValue)
    {
        if (lerpValue > 0)
        {
            defaultMusicSource.volume = lerpValue / 1.3333f;
            villageSource.volume = lerpValue / 1.3333f;
            mountiansSource.volume = lerpValue / 1.3333f;
            plainsSource.volume = lerpValue / 1.3333f;
            forestSource.volume = lerpValue / 1.3333f;
            dungeonSource.volume = lerpValue / 1.3333f;
        }
    }

    public void updateNightVolume(float lerpValue)
    {
        if (lerpValue > 0)
        {
            nightimeSource.volume = lerpValue / 1.33333f;
        }
    }

    public void updateBiomeMusicVolume(float lerpValue)
    {
        if (lerpValue > 0)
        {
            villageSource.volume = lerpValue / 1.3333f;
            mountiansSource.volume = lerpValue / 1.3333f;
            plainsSource.volume = lerpValue / 1.3333f;
            forestSource.volume = lerpValue / 1.3333f;
        }
    }

    public void updateNonBiomeMusicVolume(float lerpValue)
    {
        if (lerpValue > 0)
        {
            defaultMusicSource.volume = lerpValue / 1.3333f;
            dungeonSource.volume = lerpValue / 1.3333f;
        }
    }

    public void setDefault()
    {
        //currentBiome = BIOME.DEFAULT;
        if (!isDay)
            return;
        if(!defaultMusicSource.isPlaying)
            defaultMusicSource.Play();
    }

    public void setMountains()
    {
        //currentBiome = BIOME.MOUNTAINS;
        if (!isDay)
            return;
        if(!mountiansSource.isPlaying)
            mountiansSource.Play();
    }

    public void setVillage()
    {
        //currentBiome = BIOME.VILLAGE;
        if (!isDay)
            return;
        if (!villageSource.isPlaying) 
            villageSource.Play();
    }

    public void setDungeon()
    {
        //currentBiome = BIOME.DUNGEON;
        if (!isDay)
            return;

        if(!dungeonSource.isPlaying)
            dungeonSource.Play();
    }

    public void setPlains()
    {
        //currentBiome = BIOME.PLAINS;
        if (!isDay)
            return;
        if(!plainsSource.isPlaying)
            plainsSource.Play();
    }

    public void setForest()
    {
        //currentBiome = BIOME.FOREST;
        if (!isDay)
            return;
        if(!forestSource.isPlaying)
            forestSource.Play();
    }

    public void setNight()
    {
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

    public void stopVillage()
    {
        if (villageSource.isPlaying)
        {
            villageSource.Stop();
        }
    }

    public void stopPlains()
    {
        if (plainsSource.isPlaying)
        {
            plainsSource.Stop();
        }
    }

    public void stopForest()
    {
        if (forestSource.isPlaying)
        {
            forestSource.Stop();
        }
    }

    public void stopMountains()
    {
        if (mountiansSource.isPlaying)
        {
            mountiansSource.Stop();
        }
    }

    public void stopDefault()
    {
        if (defaultMusicSource.isPlaying)
        {
            defaultMusicSource.Stop();
        }
    }

    public void stopDungeon()
    {
        if (dungeonSource.isPlaying)
        {
            dungeonSource.Stop();
        }
    }

    public void stopNight()
    {
        if (nightimeSource.isPlaying)
        {
            nightimeSource.Stop();
        }
    }

    public void stopCurrent()
    {

        if (defaultMusicSource.isPlaying)
            defaultMusicSource.Stop();

        if (villageSource.isPlaying)
            villageSource.Stop();

        if (mountiansSource.isPlaying)
            mountiansSource.Stop();

        if (plainsSource.isPlaying)
            plainsSource.Stop();

        if (forestSource.isPlaying)
            forestSource.Stop();

        if (dungeonSource.isPlaying)
            dungeonSource.Stop();
    }
}