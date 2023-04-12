using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum Season {NONE, SPRING, SUMMER, AUTUMN, WINTER}; //MONSOON, DROUGHT
    public enum Weather {NONE, SUNNY, HOTSUN, RAIN, SNOW, HEAVYRAIN, FOGGY, WINDY, THUNDERSTORM}; //DUST

    public Season currentSeason;
    public Weather currentWeather;

    public ParticleSystem rain;
    public ParticleSystem heavyRain;
    public ParticleSystem snow;
    public ParticleSystem fog;
    public ParticleSystem wind_curved;
    public ParticleSystem wind_straight;
    public ParticleSystem storm;
    // public ParticleSystem dust;

    [Header ("Season settings")]
    public float seasonTime;
    public float springTime;
    public float summerTime;
    public float autumnTime;
    public float winterTime;

    public int currentYear;

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

    public TimeOfDay timeOfDay;
    public int currentWeek = 0;
    public List<Weather> weeklyForecast;
    private bool forecastGenerated = false;

    // [Header("UI Elements")]
    // public Text currentSeasonText;
    // public Text currentWeatherText;
    // public Image currentWeatherImage;
    // public Sprite sunnySprite;
    // public Sprite rainSprite;
    // public Sprite heavyRainSprite;
    // public Sprite stormSprite;
    // public Sprite snowSprite;
    // public Sprite windSprite;
    // public Sprite fogSprite;

    // public Text[] forecastDaysText;
    // public Image[] forecastDaysImage;

    private void Start() {
        this.currentSeason = Season.SPRING;
        this.currentWeather = Weather.SUNNY;
        this.currentYear = 1;

        this.seasonTime = this.springTime;
        this.rain.Stop();
        this.snow.Stop();
        this.heavyRain.Stop();
        // this.fog.Stop();
        this.wind_curved.Stop();
        this.wind_straight.Stop();
        this.storm.Stop();

        this.defaultLightColor = this.sunlight.color;
        this.defaultLightIntensity = this.sunlight.intensity;
        if (!forecastGenerated) {
            weeklyForecast = GenerateWeeklyForecast();
            forecastGenerated = false;
            currentWeek = timeOfDay.GetCurrentWeek();
        }
    }

    private void UpdateWeather() {
        int currentDayOfWeek = timeOfDay.GetCurrentDay();
        if (timeOfDay.GetPreviousDay() == 7 && timeOfDay.GetCurrentWeek() != currentWeek) {
            weeklyForecast = GenerateWeeklyForecast();
            currentWeek = timeOfDay.GetCurrentWeek();
        }

        switch (currentDayOfWeek) {
            case 1:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
            case 2:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
            case 3:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
            case 4:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
            case 5:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
            case 6:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
            case 7:
                ChangeWeather(this.weeklyForecast[currentDayOfWeek - 1]);
                break;
        }
    }

    public List<Weather> GenerateWeeklyForecast() {
        Season curSeason = this.currentSeason;

        List<Weather> weeklyWeather = new List<Weather>();
        for (int i = 0; i < 7; i++) {
            Weather weather = RandomizeWeather(curSeason);
            weeklyWeather.Add(weather);
        }
        return weeklyWeather;
    }

    private Weather RandomizeWeather(Season season) {
        switch (season) {
            case Season.SPRING:
                float springWeather = Random.Range(0f, 1f);
                if (springWeather < 0.4f) {
                    return Weather.RAIN;
                }
                else if (springWeather < 0.6f) {
                    return Weather.SUNNY;
                }
                else if (springWeather < 0.7f) {
                    return Weather.WINDY;
                }
                else if (springWeather < 0.8f) {
                    return Weather.FOGGY;
                }
                else if (springWeather < 0.9f) {
                    return Weather.THUNDERSTORM;
                }
                else {
                    return Weather.NONE;
                }
            case Season.SUMMER:
                float summerWeather = Random.Range(0f, 1f);
                if (summerWeather < 0.3f) {
                    return Weather.SUNNY;
                }
                else if (summerWeather < 0.6f) {
                    return Weather.HOTSUN;
                }
                else if (summerWeather < 0.7f) {
                    return Weather.RAIN;
                }
                else if (summerWeather < 0.8f) {
                    return Weather.WINDY;
                }
                else if (summerWeather < 0.9f) {
                    return Weather.THUNDERSTORM;
                }
                else {
                    return Weather.NONE;
                }
            case Season.AUTUMN:
                float autumnWeather = Random.Range(0f, 1f);
                if (autumnWeather < 0.3f) {
                    return Weather.SUNNY;
                }
                else if (autumnWeather < 0.6f) {
                    return Weather.HOTSUN;
                }
                else if (autumnWeather < 0.7f) {
                    return Weather.RAIN;
                }
                else if (autumnWeather < 0.8f) {
                    return Weather.WINDY;
                }
                else if (autumnWeather < 0.9f) {
                    return Weather.THUNDERSTORM;
                }
                else {
                    return Weather.NONE;
                }
            case Season.WINTER:
                float winterWeather = Random.Range(0f, 1f);
                if (winterWeather < 0.4f) {
                    return Weather.SNOW;
                }
                else if (winterWeather < 0.8f) {
                    return Weather.SUNNY;
                }
                else if (winterWeather < 0.9f) {
                    return Weather.RAIN;
                }
                else {
                    return Weather.NONE;
                }
            default: return Weather.NONE;
        }
    }

    public void ChangeSeason(Season seasonType) {
        if (seasonType != this.currentSeason) {
            currentSeason = seasonType;
        }
    }

    private void UpdateSeason() {
        this.seasonTime -= Time.deltaTime;

        switch (currentSeason) {
            case Season.SPRING:
                LerpLight(defaultLightColor, defaultLightIntensity + 0.15f);

                if (this.seasonTime <= 0f) {
                    ChangeSeason(Season.SUMMER);
                    this.seasonTime = this.summerTime;
                }
                break;
            case Season.SUMMER:
                if (this.seasonTime <= 0f) {
                    ChangeSeason(Season.AUTUMN);
                    this.seasonTime = this.autumnTime;
                }
                break;
            case Season.AUTUMN:
                LerpLight(autumnColor, autumnLightIntensity + 0.1f);

                if (this.seasonTime <= 0f) {
                    ChangeSeason(Season.WINTER);
                    this.seasonTime = this.winterTime;
                }
                break;
            case Season.WINTER:
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

    private void FixedUpdate(){
        UpdateSeason();
        UpdateWeather();
    }

    public void ChangeWeather(Weather weatherType) {
        if (weatherType != this.currentWeather) {
            switch (weatherType) {
                case Weather.SUNNY:
                    currentWeather = Weather.SUNNY;
                    this.rain.Stop();
                    this.snow.Stop();
                    this.heavyRain.Stop();
                    // this.fog.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    this.storm.Stop();
                    break;
                case Weather.HOTSUN:
                    currentWeather = Weather.HOTSUN;
                    this.rain.Stop();
                    this.snow.Stop();
                    this.heavyRain.Stop();
                    // this.fog.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    this.storm.Stop();
                    break;
                case Weather.RAIN:
                    currentWeather = Weather.RAIN;
                    this.rain.Play();
                    this.snow.Stop();
                    this.heavyRain.Stop();
                    // this.fog.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    this.storm.Stop();
                    break;
                case Weather.SNOW:
                    currentWeather = Weather.SNOW;
                    this.snow.Play();
                    this.rain.Stop();
                    this.heavyRain.Stop();
                    // this.fog.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    this.storm.Stop();
                    break;
                case Weather.FOGGY:
                    currentWeather = Weather.FOGGY;
                    // this.fog.Play();
                    this.rain.Stop();
                    this.snow.Stop();
                    this.heavyRain.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    this.storm.Stop();
                    break;
                case Weather.WINDY:
                    currentWeather = Weather.WINDY;
                    this.wind_curved.Play();
                    this.wind_straight.Play();
                    this.rain.Stop();
                    this.snow.Stop();
                    this.heavyRain.Stop();
                    // this.fog.Stop();
                    this.storm.Stop();
                    break;
                case Weather.THUNDERSTORM:
                    currentWeather = Weather.THUNDERSTORM;
                    this.storm.Play();
                    this.heavyRain.Play();
                    this.rain.Stop();
                    this.snow.Stop();
                    // this.fog.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    break;
                default:
                    currentWeather = Weather.NONE;
                    this.rain.Stop();
                    this.snow.Stop();
                    this.heavyRain.Stop();
                    // this.fog.Stop();
                    this.wind_curved.Stop();
                    this.wind_straight.Stop();
                    this.storm.Stop();
                    break;
            }
        }
    }
}

