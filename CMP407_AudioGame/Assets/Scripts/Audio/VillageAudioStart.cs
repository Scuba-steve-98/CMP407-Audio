using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageAudioStart : MonoBehaviour
{
    [SerializeField]
    GameObject book;

    [SerializeField]
    GameObject go;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.gameObject.GetComponent<MusicController>().setNearVillage(true);
            if (book)
            {
                book.SetActive(true);
            }
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //other.gameObject.GetComponent<MusicController>().setNearVillage(false);
        Debug.Log("Distance: " + Vector3.Distance(other.gameObject.transform.position, go.transform.position));
        if (book)
        {
            book.SetActive(false);
        }
    }
}
