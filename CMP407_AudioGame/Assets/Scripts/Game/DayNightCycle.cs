using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float dayLength = 1200f;
    float timer;
    float lerpTimer;
    Vector3 rotateValue;
    // Start is called before the first frame update
    void Start()
    {
        timer = 396f;
        rotateValue = new Vector3(118.8f, 203.3f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        lerpTimer = timer / dayLength;
        if (lerpTimer >= 1)
            timer = 0;
        rotateValue.x = Mathf.Lerp(0, 360, lerpTimer);
        gameObject.transform.eulerAngles = rotateValue;
    }
}
