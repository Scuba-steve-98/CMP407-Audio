using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField]
    GameObject gm;

    bool found = false;

    private void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if (!found)
            {
                found = true;
                Debug.Log("Book Found");
                gm.GetComponent<GameManager>().BookFound();
                Destroy(gameObject);
            }
        }
    }
}
