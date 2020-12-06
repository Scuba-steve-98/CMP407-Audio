using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject dungeon;

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearForest(true);
        dungeon.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<MusicController>().setNearForest(false);
        dungeon.SetActive(false);
    }
}
