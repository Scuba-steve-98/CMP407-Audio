using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    SFXController sfx;
    int numberBooks = 0;
    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXController>();
    }


    public void BookFound()
    {
        numberBooks++;

        sfx.PlayBook("Book" + numberBooks);

        Debug.Log("Books found: " + numberBooks);
        if (numberBooks == 3)
        {
            Debug.Log("Game Over");
            // End Game
        }
    }
}
