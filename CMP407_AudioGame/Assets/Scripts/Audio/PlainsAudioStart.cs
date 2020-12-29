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
    bool notTrigger = true;

    private void Start()
    {
        music = FindObjectOfType<MusicController>();
    }

    private void OnTriggerStay(Collider other)
    {
        lerpDistance = Vector3.Distance(go.transform.position, other.transform.position);
        lerpDistance = (lerpDistance - 155f) / 35f;


        if (lerpDistance > 0 && lerpDistance < 1)
        {
            music.updateNonBiomeMusicVolume(lerpDistance);
            music.updateBiomeMusicVolume(1 - lerpDistance);

            if (lerpDistance < 0.34f)
            {
                music.stopDefault();
                notTrigger = true;
                music.setBiome("Plain");
            }
            else if (lerpDistance > 0.66f)
            {
                notTrigger = false;
                music.stopPlains();
                music.setBiome("Def");
            }
            else if (notTrigger && lerpDistance > 0.34f && lerpDistance < 0.36f)
            {
                music.setDefault();
                notTrigger = false;
            }

            else if (!notTrigger && lerpDistance > 0.64f && lerpDistance < 0.66f)
            {
                music.setPlains();
                notTrigger = true;
            }
        }
    }
}
