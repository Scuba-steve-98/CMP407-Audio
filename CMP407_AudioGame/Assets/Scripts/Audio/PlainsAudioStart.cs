using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlainsAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject go;
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearPlains(true);
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearPlains(false);
        Debug.Log("Distance: " + Vector3.Distance(other.gameObject.transform.position, go.transform.position));
    }
}
