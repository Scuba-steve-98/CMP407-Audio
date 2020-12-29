using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDungeon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().setInDungeon(true);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<PlayerController>().setInDungeon(false);
    }
}
