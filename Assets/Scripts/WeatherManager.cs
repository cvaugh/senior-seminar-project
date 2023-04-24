using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    public enum Season {SPRING, SUMMER, AUTUMN, WINTER}; //MONSOON, DROUGHT
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
    private Weather[] weeklyForecast;
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
        currentSeason = Season.SPRING;
        currentWeather = Weather.SUNNY;
        currentYear = 1;

        seasonTime = springTime;
        rain.Stop();
        snow.Stop();
        heavyRain.Stop();
        // fog.Stop();
        wind_curved.Stop();
        wind_straight.Stop();
        storm.Stop();

        defaultLightColor = sunlight.color;
        defaultLightIntensity = sunlight.intensity;
        if(!forecastGenerated) {
            weeklyForecast = GenerateWeeklyForecast();
            forecastGenerated = true;
            currentWeek = timeOfDay.GetCurrentWeek();
        }
    }

    private void UpdateWeather() {
        int currentDayOfWeek = timeOfDay.GetCurrentDay();
        if(timeOfDay.GetPreviousDay() == 7 && timeOfDay.GetCurrentWeek() != currentWeek) {
            weeklyForecast = GenerateWeeklyForecast();
            currentWeek = timeOfDay.GetCurrentWeek();
        }

        ChangeWeather(weeklyForecast[currentDayOfWeek - 1]);
    }

    public Weather[] GenerateWeeklyForecast() {
        Weather[] weeklyWeather = new Weather[7];
        for(int i = 0; i < 7; i++) {
            weeklyWeather[i] = RandomizeWeather(currentSeason);
        }
        return weeklyWeather;
    }

    private Weather RandomizeWeather(Season season) {
        float weather = Random.Range(0f, 1f);
        switch(season) {
            case Season.SPRING:
                if(weather < 0.4f) {
                    return Weather.RAIN;
                } else if(weather < 0.6f) {
                    return Weather.SUNNY;
                } else if(weather < 0.7f) {
                    return Weather.WINDY;
                } else if(weather < 0.8f) {
                    return Weather.FOGGY;
                } else if(weather < 0.9f) {
                    return Weather.THUNDERSTORM;
                } else {
                    return Weather.NONE;
                }
            case Season.SUMMER:
                if(weather < 0.2f) {
                    return Weather.SUNNY;
                } else if(weather < 0.6f) {
                    return Weather.HOTSUN;
                } else if(weather < 0.7f) {
                    return Weather.RAIN;
                } else if(weather < 0.8f) {
                    return Weather.WINDY;
                } else if(weather < 0.9f) {
                    return Weather.THUNDERSTORM;
                } else {
                    return Weather.NONE;
                }
            case Season.AUTUMN:
                if(weather < 0.3f) {
                    return Weather.SUNNY;
                } else if(weather < 0.6f) {
                    return Weather.HOTSUN;
                } else if(weather < 0.7f) {
                    return Weather.RAIN;
                } else if(weather < 0.8f) {
                    return Weather.WINDY;
                } else if(weather < 0.9f) {
                    return Weather.THUNDERSTORM;
                } else {
                    return Weather.NONE;
                }
            case Season.WINTER:
                if(weather < 0.4f) {
                    return Weather.SNOW;
                } else if(weather < 0.8f) {
                    return Weather.SUNNY;
                } else if(weather < 0.9f) {
                    return Weather.RAIN;
                } else {
                    return Weather.NONE;
                }
            default: return Weather.NONE;
        }
    }

    public void ChangeSeason(Season seasonType) {
        if(seasonType != currentSeason) {
            currentSeason = seasonType;
        }
    }

    private void UpdateSeason() {
        seasonTime -= Time.deltaTime;

        switch(currentSeason) {
            case Season.SPRING:
                LerpLight(defaultLightColor, defaultLightIntensity + 0.15f);

                if(seasonTime <= 0f) {
                    ChangeSeason(Season.SUMMER);
                    seasonTime = summerTime;
                }
                break;
            case Season.SUMMER:
                if(seasonTime <= 0f) {
                    ChangeSeason(Season.AUTUMN);
                    seasonTime = autumnTime;
                }
                break;
            case Season.AUTUMN:
                LerpLight(autumnColor, autumnLightIntensity + 0.1f);

                if(seasonTime <= 0f) {
                    ChangeSeason(Season.WINTER);
                    seasonTime = winterTime;
                }
                break;
            case Season.WINTER:
                LerpLight(winterColor, winterLightIntensity + 0.15f);

                if(seasonTime <= 0f) {
                    currentYear ++;
                    ChangeSeason(Season.SPRING);
                    seasonTime = springTime;
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
        rain.Stop();
        snow.Stop();
        heavyRain.Stop();
        // fog.Stop();
        wind_curved.Stop();
        wind_straight.Stop();
        storm.Stop();
        if(weatherType != currentWeather) {
            switch(weatherType) {
                case Weather.RAIN:
                    rain.Play();
                    break;
                case Weather.SNOW:
                    snow.Play();
                    break;
                case Weather.FOGGY:
                    // fog.Play();
                    break;
                case Weather.WINDY:
                    wind_curved.Play();
                    wind_straight.Play();
                    break;
                case Weather.THUNDERSTORM:
                    storm.Play();
                    heavyRain.Play();
                    break;
                default:
                    break;
            }
        }
        currentWeather = weatherType;
    }
}

