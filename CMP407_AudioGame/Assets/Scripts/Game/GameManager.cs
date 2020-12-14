using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioController audioController;
    int numberBooks = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioController = FindObjectOfType<AudioController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void BookFound()
    {
        numberBooks++;

        audioController.Play("Found" + numberBooks);

        Debug.Log("Books found: " + numberBooks);
        if (numberBooks == 3)
        {
            Debug.Log("Game Over");
            // End Game
        }
    }
}
