using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterAreaAudio : MonoBehaviour
{
    float lerpDistance;

    bool nearDungeon = false;
    bool musicTrigger = false;
    bool notTrigger = true;

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


        if (lerpDistance > 0 && lerpDistance < 1)
        {
            music.updateNonBiomeMusicVolume(1 - lerpDistance);
            music.updateBiomeMusicVolume(lerpDistance);

            if (lerpDistance < 0.34f)
            {
                music.stopForest();
                music.stopMountains();
                notTrigger = true;
            }
            else if (lerpDistance > 0.66f)
            {
                notTrigger = false;
                music.stopDungeon();
            }
            else if (notTrigger && lerpDistance > 0.34f && lerpDistance < 0.36f)
            {
                if (isMountains)
                {
                    music.setMountains();
                }
                else if (!isMountains)
                {
                    music.setForest();
                }
                notTrigger = false;
            }

            else if (!notTrigger && lerpDistance > 0.64f && lerpDistance < 0.66f)
            {
                music.setDungeon();
                notTrigger = true;
            }
        }
    }
}