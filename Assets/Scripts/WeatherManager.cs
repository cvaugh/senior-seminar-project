using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum Season {NONE, SPRING, SUMMER, AUTUMN, WINTER}; //MONSOON, DROUGHT
    public enum Weather {NONE, SUNNY, HOTSUN, RAIN, SNOW}; //HEAVYRAIN, FOGGY, WINDY, THUNDERSTORM

    public Season currentSeason;
    public Weather currentWeather;

    public ParticleSystem rain;
    //public ParticleSystem heavyRain;
    public ParticleSystem snow;
    //public ParticleSystem fog;
    //public ParticleSystem wind;
    //public ParticleSystem storm;
    //public ParticleSystem dust;

    [Header ("Season settings")]
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
        this.snow.Stop();

        this.defaultLightColor = this.sunlight.color;
        this.defaultLightIntensity = this.sunlight.intensity;
    }

    public void ChangeSeason(Season seasonType) {
        if (seasonType != this.currentSeason) {
            currentSeason = seasonType;
        }
    }

    public void ChangeWeather(Weather weatherType) {
        if (weatherType != this.currentWeather) {
            currentWeather = weatherType;
            switch (currentWeather) {
                case Weather.RAIN:
                    rain.Play();
                    snow.Stop();
                    break;
                case Weather.SNOW:
                    snow.Play();
                    rain.Stop();
                    break;
                // case Weather.FOGGY:
                //     fog.Play();
                //     break;
                // case Weather.WINDY:
                //     wind.Play();
                //     break;
                // case Weather.THUNDERSTORM:
                //     storm.Play();
                //     break;
                default:
                    rain.Stop();
                    snow.Stop();
                    break;
            }
        }
    }

    private void Update() {
        this.seasonTime -= Time.deltaTime;

        switch (currentSeason) {
        case Season.SPRING:
            ChangeWeather(Weather.SUNNY);

            LerpLight(defaultLightColor, defaultLightIntensity + 0.15f);

            if (this.seasonTime <= 0f) {
                ChangeSeason(Season.SUMMER);
                this.seasonTime = this.summerTime;
            }
            break;
        case Season.SUMMER:
            ChangeWeather(Weather.HOTSUN);

            LerpLight(summerColor, summerLightIntensity + 0.3f);

            if (this.seasonTime <= 0f) {
                ChangeSeason(Season.AUTUMN);
                this.seasonTime = this.autumnTime;
            }
            break;
        case Season.AUTUMN:
            ChangeWeather(Weather.RAIN);

            LerpLight(autumnColor, autumnLightIntensity + 0.1f);

            if (this.seasonTime <= 0f) {
                ChangeSeason(Season.WINTER);
                this.seasonTime = this.winterTime;
            }
            break;
        case Season.WINTER:
            ChangeWeather(Weather.SNOW);

            LerpLight(winterColor, winterLightIntensity + 0.15f);

            if (this.seasonTime <= 0f) {
                this.currentYear ++;
                ChangeSeason(Season.SPRING);
                this.seasonTime = this.springTime;
            }
            break;
    }
    }

    private void LerpLight(Color c, float intensity) {
        sunlight.color = Color.Lerp(sunlight.color, c, 0.2f * Time.deltaTime);
        sunlight.intensity = Mathf.Lerp(sunlight.intensity, intensity, 0.2f * Time.deltaTime);
    }

}
