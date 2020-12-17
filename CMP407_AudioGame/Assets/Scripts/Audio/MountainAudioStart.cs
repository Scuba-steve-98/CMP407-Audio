using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject dungeon;
    [SerializeField]
    GameObject go;
    [SerializeField]
    bool isMountain;

    MusicController music;

    float lerpDistance;

    bool isInBiome = false;
    bool audioTrigger = false;

    private void Start()
    {
        music = FindObjectOfType<MusicController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        dungeon.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        dungeon.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        lerpDistance = Vector3.Distance(go.transform.position, other.transform.position);

        if (isMountain)
        {
            lerpDistance = (lerpDistance - 360f) / 40f;
        }
        else if (!isMountain)
        {
            lerpDistance = (lerpDistance - 110f) / 30f;
        }

        if (lerpDistance > 0.5f)
        {
            isInBiome = false;
        }

        if (lerpDistance < 0.5f && lerpDistance > 0f)
        {
            if (!audioTrigger)
            {
                if (isMountain)
                {
                    music.setMountains();
                }
                else if (!isMountain)
                {
                    music.setForest();
                }
                audioTrigger = true;
            }
            isInBiome = true;
            music.updateMusicVolume(1 - lerpDistance);
        }
        else if (lerpDistance > 0.5f && !isInBiome)
        {
            if (audioTrigger)
            {
                music.setDefault();
                audioTrigger = false;
                Debug.Log("Left Mount");
            }
            music.updateMusicVolume(lerpDistance);
        }
    }
}
