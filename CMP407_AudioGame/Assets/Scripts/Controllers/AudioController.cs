using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    bool isOnWater;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setInWater(bool water)
    {
        isOnWater = water;
        Debug.Log("water" + isOnWater);
    }

    public void updateDepthInWater(float water)
    {
        float depth = gameObject.transform.position.y - water;
        Debug.Log("Water: " + (gameObject.transform.position.y - 3.92f));
        Debug.Log("Depth: " + depth);
    }
}
