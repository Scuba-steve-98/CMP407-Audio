using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    bool isNearDungeon = false;
    bool isNearMountains = false;
    bool isNearForest = false;
    bool isNearVillage = false;
    bool isNearPlains = false;
    bool isOnWater = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearForest)
        {
            // Dungeon Music
        }
        else if (isNearMountains)
        {

        }
        else if (isNearPlains)
        {

        }
    }

    public void setNearForest(bool near)
    {
        isNearForest = near;
        Debug.Log("Forest" + near);
    }

    public void setNearMountains(bool near)
    {
        isNearMountains = near;
        Debug.Log("Mountains" + near);
    }

    public void setNearPlains(bool near)
    {
        isNearPlains = near;
        Debug.Log("Plains" + near);
    } 
    
    public void setNearVillage(bool near)
    {
        isNearVillage = near;
        Debug.Log("Village" + near);
    }
}
