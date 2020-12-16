using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject dungeon;
    [SerializeField]
    GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearMountains(true);
        dungeon.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearMountains(false);
        //Debug.Log("Distance: " + Vector3.Distance(other.gameObject.transform.position, go.transform.position));
        dungeon.SetActive(false);
    }
}
