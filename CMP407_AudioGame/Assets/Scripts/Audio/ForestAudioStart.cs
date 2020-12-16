using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject dungeon;
    [SerializeField]
    GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearForest(true);
        dungeon.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearForest(false);
        Debug.Log("Distance: " + Vector3.Distance(other.gameObject.transform.position, go.transform.position));
        dungeon.SetActive(false);
    }
}
