using UnityEngine;

public class TimeOfDay : MonoBehaviour {
    public float dayDurationSeconds = 10f;
    public Light sun;
    public float currentTimeOfDay;
    private float timeMultiplier = 1f;
    private float sunInitialIntensity;
    private int currentDayOfWeek = 1;
    public int weeks = 0;

    private void Start() {
        sun = GameObject.Find("Directional Light").GetComponent<Light>();

        if(sun == null) {
            Debug.LogError("No directional light found");
            sunInitialIntensity = 1.2f;
        } else {
            sunInitialIntensity = sun.intensity;
        }
    }

    private void UpdateSun() {
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);

        float intensityMultiplier = 1;
        if(currentTimeOfDay <= 0.23f || currentTimeOfDay >= 0.75f) {
            intensityMultiplier = 0.01f;
        } else if(currentTimeOfDay <= 0.25f) {
            intensityMultiplier = Mathf.Clamp01((currentTimeOfDay - 0.23f) * (1 / 0.02f));
        } else if(currentTimeOfDay >= 0.73f) {
            intensityMultiplier = Mathf.Clamp01(1 - ((currentTimeOfDay - 0.73f) * (1 / 0.02f)));
        }

        sun.intensity = sunInitialIntensity * intensityMultiplier;
    }

    private void Update() {
        currentTimeOfDay += Time.deltaTime / dayDurationSeconds * timeMultiplier;

        if(currentTimeOfDay >= 1) {
            currentTimeOfDay = 0;
            currentDayOfWeek++;

            if(currentDayOfWeek > 7) {
                currentDayOfWeek = 1;
                weeks++;
            }
        }

        UpdateSun();
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
        if(previousDayOfWeek == 0) {
            previousDayOfWeek = 7;
        }
        return previousDayOfWeek;
    }
}
