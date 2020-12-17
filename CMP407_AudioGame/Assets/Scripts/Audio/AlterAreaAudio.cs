using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterAreaAudio : MonoBehaviour
{
    float lerpDistance;

    bool nearDungeon = false;
    bool musicTrigger = false;

    MusicController music;
    Vector3 colliderPos;

    [SerializeField]
    bool isMountains;

    private void Start()
    {
        music = FindObjectOfType<MusicController>();
        colliderPos = gameObject.transform.position;
        colliderPos.x += 10;
    }


    private void OnTriggerStay(Collider other)
    {
        lerpDistance = Vector3.Distance(other.gameObject.transform.position, colliderPos);
        lerpDistance = (lerpDistance - 25f) / 25f;

        if (lerpDistance > 0.5f)
        {
            nearDungeon = false;
        }

        if (lerpDistance < 0.5f && lerpDistance > 0f)
        {
            if (!musicTrigger)
            {
                music.setDungeon();
                musicTrigger = true; 
            }
            nearDungeon = true;
            music.updateMusicVolume(1 - lerpDistance);
        }
        else if (lerpDistance > 0.5f && !nearDungeon)
        {
            if (musicTrigger)
            {
                if (isMountains)
                {
                    music.setMountains();
                }
                else if (!isMountains)
                {
                    music.setForest();
                }
                musicTrigger = false;
            }

            music.updateMusicVolume(lerpDistance);
        }
    }
}