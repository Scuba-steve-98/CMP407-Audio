using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float timer;
    float offset = 90f;
    Vector3 rotateValue;

    bool isNight = false;

    [SerializeField]
    Light Sun;

    [SerializeField]
    LightingPreset preset;

    [SerializeField]
    [Range(0, 24)]
    float timeOfDay;

    [SerializeField]
    float timeMultiplier = 0;

    MusicController music;
    // Start is called before the first frame update
    void Start()
    {
        timer = 396f;
        rotateValue = new Vector3(0f, 203f, 0f);
        music = FindObjectOfType<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!preset)
            return;

        if(Application.isPlaying)
        {
            timeOfDay += Time.deltaTime / timeMultiplier;
            if (timeOfDay > 24)
                timeOfDay = 0;
            timer = timeOfDay / 24f;

            if (timeOfDay > 8.50f && timeOfDay < 9.10f)
            {
                if (timeOfDay < 8.8f)
                {
                    // lerp audio
                    float lerpVal = -(timeOfDay - 8.8f) * 3.333333332f;
                    music.updateMusicVolume(lerpVal);
                    Debug.Log("Transition from Night" + (-(timeOfDay - 8.8f) * 3.333333332f));
                }

                if (timeOfDay > 8.8f && timeOfDay < 19.0f && isNight)
                {
                    isNight = false;
                    music.setToDay(true);
                    Debug.Log("Now it's Day");
                }

                if (timeOfDay > 8.8f)
                {
                    float lerpVal = (timeOfDay - 8.8f) * 3.333333332f;
                    music.updateMusicVolume(lerpVal);
                    Debug.Log("Transition to Day" +  ((timeOfDay - 8.8f) * 3.333333332f));
                }
            }

            if (timeOfDay > 19.70f && timeOfDay < 20.30f)
            {
                if (timeOfDay < 20.0f)
                {
                    // lerp audio
                    float lerpVal = -(timeOfDay - 20.0f) * 3.333333332f;
                    music.updateMusicVolume(lerpVal);
                    Debug.Log("Transition from Day" + (-(timeOfDay - 20.0f) * 3.333333332f));
                }

                if ((timeOfDay > 8.8f || timeOfDay < 20.0f) && !isNight)
                {
                    isNight = true;
                    music.setToDay(false);
                    music.setNight();
                    Debug.Log("Now it's Night");
                }

                if (timeOfDay > 20.0f)
                {
                    float lerpVal = (timeOfDay - 20.0f) * 3.333333332f;
                    music.updateMusicVolume(lerpVal);
                    Debug.Log("Transition to Night" + ((timeOfDay - 20.0f) * 3.333333332f));
                }
            }
            RenderSettings.ambientLight = preset.AmbientColour.Evaluate(timer);

            Sun.color = preset.DirectionalColour.Evaluate(timer);
            rotateValue.x = (timer * 360) - offset;
            Sun.transform.localRotation = Quaternion.Euler(rotateValue);
        }
    }
}
