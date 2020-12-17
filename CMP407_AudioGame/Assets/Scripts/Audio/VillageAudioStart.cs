using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject book;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (book)
            {
                book.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Distance: " + Vector3.Distance(other.gameObject.transform.position, go.transform.position));
        if (book)
        {
            book.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        lerpDistance = Vector3.Distance(go.transform.position, other.transform.position);
        lerpDistance = (lerpDistance - 100f) / 25f;

        if (lerpDistance > 0.5f)
        {
            inVillage = false;
        }

        if (lerpDistance < 0.5f && lerpDistance > 0f)
        {
            if (!musicTrigger)
            {
                music.setVillage();
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
