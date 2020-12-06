using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainAudioStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearMountains(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearMountains(false);
    }
}
