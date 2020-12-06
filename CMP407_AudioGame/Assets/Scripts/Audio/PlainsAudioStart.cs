using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainsAudioStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearPlains(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearPlains(false);
    }
}
