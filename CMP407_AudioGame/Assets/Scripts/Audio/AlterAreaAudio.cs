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
    string biomeName;

    private void Start()
    {
        music = FindObjectOfType<MusicController>();
        colliderPos = gameObject.transform.position;
        colliderPos.x += 10;
    }


    private void OnTriggerStay(Collider other)
    {
        lerpDistance = Vector3.Distance(other.gameObject.transform.position, colliderPos);
        lerpDistance = (lerpDistance - 20f) / 10f;
        //Debug.Log("Lerp: " + lerpDistance);

        if (lerpDistance > 0.5f)
        {
            nearDungeon = false;
        }

        if (lerpDistance < 0.5f && lerpDistance > 0f)
        {
            if (!musicTrigger)
            {
                Debug.Log("Yeet");
                music.stopMountains();
                music.setDungeon();
                //music.Stop(biomeName);
                //music.Play("Dungeon");
                musicTrigger = true; 
            }
            nearDungeon = true;
            //music.updateMusicVolume(/*"Dungeon", */1 - lerpDistance);
        }
        else if (lerpDistance > 0.5f && !nearDungeon)
        {
            if (musicTrigger)
            {
                music.setDefault();
                //music.Stop("Dungeon");
                //music.Play(biomeName);
                musicTrigger = false;
            }

            //music.updateMusicVolume(/*biomeName,*/ lerpDistance);
        }
    }
}