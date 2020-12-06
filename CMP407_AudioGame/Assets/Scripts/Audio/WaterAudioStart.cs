using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAudioStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<AudioController>().setInWater(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<AudioController>().setInWater(false);
    }

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<AudioController>().updateDepthInWater(gameObject.transform.position.y);
    }
}
