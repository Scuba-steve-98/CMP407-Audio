using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterAreaAudio : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Near Dungeon");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Left Dungeon");
        }
    }
}
