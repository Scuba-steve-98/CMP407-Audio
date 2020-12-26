using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAudio : MonoBehaviour
{
    SFXController sfx;
    [SerializeField]
    GameObject player;

    [SerializeField]
    bool isPlains;

    Vector3 targetPos;

    float timer = 0;
    float trigger = 0;

    // Start is called before the first frame update
    void Start()
    {
        sfx = FindObjectOfType<SFXController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0;
        trigger = Random.Range(0.3f, 0.7f) * 8f;
        Debug.Log(trigger);
    }

    private void OnTriggerStay(Collider other)
    {
        timer += Time.deltaTime;

        if (timer > trigger)
        {
            if (isPlains)
            {
                targetPos = player.transform.position + (Vector3.up * Random.Range(1, 4) + Vector3.forward * Random.Range(-6, 6) + Vector3.right * Random.Range(-6, 6));
                int q = Random.Range(1, 4);
                sfx.PlayCricket("Cricket" + q, targetPos);
            }
            else if (!isPlains)
            {
                targetPos = player.transform.position + (Vector3.forward * Random.Range(-6, 6) + Vector3.right * Random.Range(-6, 6));
                int q = Random.Range(1, 6);
                sfx.PlayBird("Bird" + q, targetPos);
            }
            timer = 0;
            trigger = Random.Range(0.3f, 0.7f) * 8f;
        }

        
    }
}
