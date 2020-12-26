using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    float timer;
    float offset = 90f;

    bool isNight = false;
    bool notTriggered = true;

    Vector3 rotateValue;
    MusicController music;


    [SerializeField]
    Light Sun;

    [SerializeField]
    LightingPreset preset;

    [SerializeField]
    [Range(0, 24)]
    float timeOfDay;

    [SerializeField]
    float timeMultiplier = 0;

    // Start is called before the first frame update
    void Start()
    {
        //timer = 396f;
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
                if (timeOfDay > 8.695f && timeOfDay < 8.705f && notTriggered)
                {
                    music.setToDay(true);
                    notTriggered = false;
                }

                if (timeOfDay > 8.895f && timeOfDay < 8.905f && !notTriggered)
                {
                    music.stopNight();
                    notTriggered = true;
                }

                float lerpVal = (9.1f - timeOfDay) / 0.6f;
                music.updateNightVolume(lerpVal);
                music.updateAllDayMusicVolume(1 - lerpVal);
            }

            // set timeframe for changing day to night
            if (timeOfDay > 19.70f && timeOfDay < 20.30f)
            {
                if (timeOfDay > 19.895f && timeOfDay < 19.905f && notTriggered)
                {
                    music.setNight();
                    music.setToDay(false);
                    notTriggered = false;
                }

                if (timeOfDay > 20.095f && timeOfDay < 20.105f && !notTriggered)
                {
                    music.stopCurrent();
                    notTriggered = true;
                }

                float lerpVal = (9.1f - timeOfDay) / 0.6f;
                music.updateNightVolume(1 - lerpVal);
                music.updateAllDayMusicVolume(lerpVal);
            }


            // Lighting stuff
            RenderSettings.ambientLight = preset.AmbientColour.Evaluate(timer);

            Sun.color = preset.DirectionalColour.Evaluate(timer);
            rotateValue.x = (timer * 360) - offset;
            Sun.transform.localRotation = Quaternion.Euler(rotateValue);
        }
    }
}
