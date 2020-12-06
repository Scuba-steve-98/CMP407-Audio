using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageAudioStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearVillage(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearVillage(false);
    }
}
