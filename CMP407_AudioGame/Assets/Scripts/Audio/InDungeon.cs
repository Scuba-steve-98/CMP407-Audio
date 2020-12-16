using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDungeon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<Movement>().setInDungeon(true);
        //Debug.Log("In Dungeon");
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<Movement>().setInDungeon(false);
        //Debug.Log("Left Dungeon");
    }
}
