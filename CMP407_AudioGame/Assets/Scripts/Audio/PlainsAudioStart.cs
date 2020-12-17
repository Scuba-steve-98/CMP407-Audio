using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainsAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject go;

    MusicController music;

    float lerpDistance;

    bool inVillage = false;
    bool musicTrigger = false;

    private void Start()
    {
        music = FindObjectOfType<MusicController>();
    }

    private void OnTriggerStay(Collider other)
    {
        lerpDistance = Vector3.Distance(go.transform.position, other.transform.position);
        lerpDistance = (lerpDistance - 155f) / 35f;

        if (lerpDistance > 0.5f)
        {
            inVillage = false;
        }

        if (lerpDistance < 0.5f && lerpDistance > 0f)
        {
            if (!musicTrigger)
            {
                music.setPlains();
                musicTrigger = true;
            }
            inVillage = true;
            music.updateMusicVolume(1 - lerpDistance);
        }
        else if (lerpDistance > 0.5f && !inVillage)
        {
            if (musicTrigger)
            {
                music.setDefault();
                musicTrigger = false;
            }

            music.updateMusicVolume(lerpDistance);
        }
    }
}
