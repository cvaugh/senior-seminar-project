using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum Season {NONE, SPRING, SUMMER, AUTUMN, WINTER};
    public enum Weather {NONE, SUNNY, HOTSUN, RAIN, SNOW};

    public Season currentSeason;
    public Weather currentWeather;

    public ParticleSystem rain;
    //public ParticleSystem heavyRain;
    //public ParticleSystem snow;

    [Header ("Time settings")]
    public float seasonTime;
    public float springTime;
    public float summerTime;
    public float autumnTime;
    public float winterTime;

    [Header ("Light settings")]
    public Light sunlight;
    private float defaultLightIntensity;
    public float summerLightIntensity;
    public float autumnLightIntensity;
    public float winterLightIntensity;

    private Color defaultLightColor;
    public Color summerColor;
    public Color autumnColor;
    public Color winterColor;

    public int currentYear;

    private void Start() {
        this.currentSeason = Season.SPRING;
        this.currentWeather = Weather.SUNNY;
        this.currentYear = 1;

        this.seasonTime = this.springTime;
        this.rain.Stop();

        this.defaultLightColor = this.sunlight.color;
        this.defaultLightIntensity = this.sunlight.intensity;
    }

    public void ChangeSeason(Season seasonType) {
        if (seasonType != this.currentSeason) {
            switch (seasonType) {
                case Season.SPRING:
                    currentSeason = Season.SPRING;
                    break;
                case Season.SUMMER:
                    currentSeason = Season.SUMMER;
                    break;
                case Season.AUTUMN:
                    currentSeason = Season.AUTUMN;
                    break;
                case Season.WINTER:
                    currentSeason = Season.WINTER;
                    break;
            }
        }
    }

    public void ChangeWeather(Weather weatherType) {
        if (weatherType != this.currentWeather) {
            switch (weatherType) {
                case Weather.SUNNY:
                    currentWeather = Weather.SUNNY;
                    this.rain.Stop();
                    break;
                case Weather.HOTSUN:
                    currentWeather = Weather.HOTSUN;
                    this.rain.Stop();
                    break;
                case Weather.RAIN:
                    currentWeather = Weather.RAIN;
                    this.rain.Play();
                    break;
                case Weather.SNOW:
                    currentWeather = Weather.SNOW;
                    this.rain.Stop();
                    break;
            }
        }
    }

    private void FixedUpdate() {
        this.seasonTime -= Time.deltaTime;

        if (this.currentSeason == Season.SPRING) {
            ChangeWeather(Weather.SUNNY);

            LerpSunIntesity(this.sunlight, defaultLightIntensity);
            LerpLightColor(this.sunlight, defaultLightColor);

            if (this.seasonTime <= 0f) {
                ChangeSeason(Season.SUMMER);
                this.seasonTime = this.summerTime;
            }
        }
        else if (this.currentSeason == Season.SUMMER) {
            ChangeWeather(Weather.HOTSUN);

            LerpSunIntesity(this.sunlight, summerLightIntensity);
            LerpLightColor(this.sunlight, summerColor);

            if (this.seasonTime <= 0f) {
                ChangeSeason(Season.AUTUMN);
                this.seasonTime = this.autumnTime;
            }
        }
        else if (this.currentSeason == Season.AUTUMN) {
            ChangeWeather(Weather.RAIN);

            LerpSunIntesity(this.sunlight, autumnLightIntensity);
            LerpLightColor(this.sunlight, autumnColor);

            if (this.seasonTime <= 0f) {
                ChangeSeason(Season.WINTER);
                this.seasonTime = this.winterTime;
            }
        }
        else if (this.currentSeason == Season.WINTER) {
            ChangeWeather(Weather.SNOW);

            LerpSunIntesity(this.sunlight, winterLightIntensity);
            LerpLightColor(this.sunlight, winterColor);

            if (this.seasonTime <= 0f) {
                this.currentYear ++;
                ChangeSeason(Season.SPRING);
                this.seasonTime = this.springTime;
            }
        }
    }

    private void LerpLightColor(Light light, Color c) {
        light.color = Color.Lerp(light.color, c, 0.2f * Time.deltaTime);
    }

    private void LerpSunIntesity(Light light, float intensity) {
        light.intensity = Mathf.Lerp(light.intensity, intensity, 0.2f * Time.deltaTime);
    }
}
