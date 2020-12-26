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
    bool notTrigger = true;

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
            lerpDistance = (lerpDistance - 100f) / 30f;
        }
        // ------------------------------------------------------------------------------------------------------------



        if (lerpDistance > 0 && lerpDistance < 1)
        {
            music.updateNonBiomeMusicVolume(lerpDistance);
            music.updateBiomeMusicVolume(1 - lerpDistance);

            if (lerpDistance < 0.34f)
            {
                music.stopDefault();
                notTrigger = true;
            }
            else if (lerpDistance > 0.66f)
            {
                notTrigger = false;
                music.stopForest();
                music.stopMountains();
            }
            else if (notTrigger && lerpDistance > 0.34f && lerpDistance < 0.36f)
            {
                music.setDefault();
                notTrigger = false;
            }

            else if (!notTrigger && lerpDistance > 0.64f && lerpDistance < 0.66f)
            {
                if (isMountain)
                {
                    music.setMountains();
                }
                else if (!isMountain)
                {
                    music.setForest();
                }
                notTrigger = true;
            }
        }
    }
}
