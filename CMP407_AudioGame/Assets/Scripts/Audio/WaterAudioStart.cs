using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAudioStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //other.gameObject.GetComponent<AudioController>().setInWater(true);
        other.gameObject.GetComponent<Movement>().setInWater(true);
        other.gameObject.GetComponent<Movement>().setWaterStart(other.gameObject.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<AudioController>().setInWater(false);
        other.gameObject.GetComponent<Movement>().setInWater(false);
    }

    private void OnTriggerStay(Collider other)
    {
        //other.gameObject.GetComponent<AudioController>().updateDepthInWater(gameObject.transform.position.y);
        other.gameObject.GetComponent<Movement>().updateDepthInWater(gameObject.transform.position.y);
    }
}
