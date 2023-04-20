using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOfDay : MonoBehaviour
{
    public float dayDurationSeconds = 10f;
    public Light sun;
    public float currentTimeOfDay = 0f;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    private int currentDayOfWeek = 1;
    private int previousDayOfWeek;
    public int weeks = 0;

    private void Start() {
        sun = GameObject.Find("Directional Light").GetComponent<Light>();

        if (sun == null) {
            Debug.LogError("No directional light found");
        }
        sunInitialIntensity = sun.intensity;
    }

    private void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if (currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
            intensityMultiplier = 0;
        }
        else if (currentTimeOfDay <= 0.25f) {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        }
        else if (currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    private void Update() {
        UpdateSun();

        currentTimeOfDay += (Time.deltaTime / dayDurationSeconds) * timeMultiplier;

        if (currentTimeOfDay >= 1) {
            currentTimeOfDay = 0;
            currentDayOfWeek ++;

            if (currentDayOfWeek > 7) {
                currentDayOfWeek = 1;
                weeks ++;
            }
        }
    }

    public int GetCurrentHour() {
        int currentHour = Mathf.RoundToInt(currentTimeOfDay * 24f);
        return currentHour;
    }

    public int GetCurrentDay() {
        return currentDayOfWeek;
    }

    public int GetCurrentWeek() {
        return weeks;
    }

    public int GetPreviousDay() {
        int previousDayOfWeek = currentDayOfWeek - 1;
        if (previousDayOfWeek == 0) {
            previousDayOfWeek = 7;
        }
        return previousDayOfWeek;
    }
}
