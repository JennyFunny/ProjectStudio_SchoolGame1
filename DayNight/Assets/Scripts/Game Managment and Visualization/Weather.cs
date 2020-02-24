using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weather : MonoBehaviour
{

    public float _switchWeatherTimer = 0f;
    public float resetWeatherTimer = 20f;

    public WeatherStates weatherState;
    private int switchWeather;

    public float audioFadeTime = 0.25f;
    public AudioClip sunAudio;
    public AudioClip thunderAudio;
    public AudioClip mistAudio;
    public AudioClip overcastAudio;
    public AudioClip snowAudio;

    public float lightDimTime = 0.1f;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float mistIntensity = 0.75f;
    public float thunderIntensity = 0.5f;
    public float overcastIntensity = 0.45f;
    public float snowIntensity = 0.75f;

    ParticleSystem RainParticles = null;
    ParticleSystem MistParticles = null;
    ParticleSystem SnowParticles = null;

    public Light sun;

    public AudioSource weatherAudio;

    public enum WeatherStates
    {
        PickWeather,
        SunnyWeather,
        ThunderWeather,
        MistWeather,
        OvercastWeather,
        SnowWeather
    }

    private void Awake()
    {
        StartCoroutine(WeatherFSM());
    }

    private void Update()
    {
        RainParticles = GameObject.FindGameObjectWithTag("Rain").GetComponent<ParticleSystem>();
        MistParticles = GameObject.FindGameObjectWithTag("Mist").GetComponent<ParticleSystem>();
        SnowParticles = GameObject.FindGameObjectWithTag("Snow").GetComponent<ParticleSystem>();

        if (RainParticles != null)
        {
            SwitchWeatherTimer();
            RainParticles.Stop();
            MistParticles.Stop();
            SnowParticles.Stop();

            _switchWeatherTimer -= Time.deltaTime;

            if (_switchWeatherTimer < 0)
                _switchWeatherTimer = 0;

            if (_switchWeatherTimer > 0)
                return;

            if (_switchWeatherTimer == 0)
                weatherState = Weather.WeatherStates.PickWeather;

            _switchWeatherTimer = resetWeatherTimer;
        }
    }

    void SwitchWeatherTimer()
    {
        Debug.Log("Switch Weather");

       
    }

    IEnumerator WeatherFSM()
    {
        while (true)
        {
            switch (weatherState)
            {
                case WeatherStates.PickWeather:
                    PickWeather();
                    break;
                case WeatherStates.SunnyWeather:
                    SunnyWeather();
                    break;
                case WeatherStates.ThunderWeather:
                    ThunderWeather();
                    break;
                case WeatherStates.MistWeather:
                    MistWeather();
                    break;
                case WeatherStates.OvercastWeather:
                    OvercastWeather();
                    break;
                case WeatherStates.SnowWeather:
                    SnowWeather();
                    break;
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void PickWeather()
    {
        switchWeather = Random.Range(0, 5);

        switch (switchWeather)
        {
            case 0:
                weatherState = Weather.WeatherStates.SunnyWeather;
                break;
            case 1:
                weatherState = Weather.WeatherStates.ThunderWeather;
                break;
            case 2:
                weatherState = Weather.WeatherStates.MistWeather;
                break;
            case 3:
                weatherState = Weather.WeatherStates.OvercastWeather;
                break;
            case 4:
                weatherState = Weather.WeatherStates.SnowWeather;
                break;
        }
    }

    void SunnyWeather()
    {
        Debug.Log("Sunny");

        if (Daynight.Day)
        {
            if (sun.intensity > maxIntensity)
                sun.intensity -= Time.deltaTime * lightDimTime;

            if (sun.intensity < maxIntensity)
                sun.intensity += Time.deltaTime * lightDimTime;
        }
        if (weatherAudio.volume > 0 && weatherAudio.clip != sunAudio)
            weatherAudio.volume -= Time.deltaTime * audioFadeTime;

        if(weatherAudio.volume == 0)
        {
            weatherAudio.Stop();
            weatherAudio.clip = sunAudio;
            weatherAudio.loop = true;
            weatherAudio.Play();
        }

        if (weatherAudio.volume < 1 && weatherAudio.clip == sunAudio)
            weatherAudio.volume += Time.deltaTime * audioFadeTime;
    }

    void ThunderWeather()
    {
        Debug.Log("Thunder");

        RainParticles.Play();

        if (Daynight.Day)
        {
            if (sun.intensity > thunderIntensity)
                sun.intensity -= Time.deltaTime * lightDimTime;

            if (sun.intensity < thunderIntensity)
                sun.intensity += Time.deltaTime * lightDimTime;
        }
        if (weatherAudio.volume > 0 && weatherAudio.clip != thunderAudio)
            weatherAudio.volume -= Time.deltaTime * audioFadeTime;

        if (weatherAudio.volume == 0)
        {
            weatherAudio.Stop();
            weatherAudio.clip = thunderAudio;
            weatherAudio.loop = true;
            weatherAudio.Play();
        }

        if (weatherAudio.volume < 1 && weatherAudio.clip == thunderAudio)
            weatherAudio.volume += Time.deltaTime * audioFadeTime;
    }

    void MistWeather()
    {
        Debug.Log("Mist");

        MistParticles.Play();

        if (Daynight.Day)
        {
            if (sun.intensity > mistIntensity)
                sun.intensity -= Time.deltaTime * lightDimTime;

            if (sun.intensity < mistIntensity)
                sun.intensity += Time.deltaTime * lightDimTime;
        }
        if (weatherAudio.volume > 0 && weatherAudio.clip != mistAudio)
            weatherAudio.volume -= Time.deltaTime * audioFadeTime;

        if (weatherAudio.volume == 0)
        {
            weatherAudio.Stop();
            weatherAudio.clip = mistAudio;
            weatherAudio.loop = true;
            weatherAudio.Play();
        }

        if (weatherAudio.volume < 1 && weatherAudio.clip == mistAudio)
            weatherAudio.volume += Time.deltaTime * audioFadeTime;
    }

    void OvercastWeather()
    {
        Debug.Log("Overcast");
        if (Daynight.Day)
        {
            if (sun.intensity > overcastIntensity)
                sun.intensity -= Time.deltaTime * lightDimTime;

            if (sun.intensity < overcastIntensity)
                sun.intensity += Time.deltaTime * lightDimTime;
        }
        if (weatherAudio.volume > 0 && weatherAudio.clip != overcastAudio)
            weatherAudio.volume -= Time.deltaTime * audioFadeTime;

        if (weatherAudio.volume == 0)
        {
            weatherAudio.Stop();
            weatherAudio.clip = overcastAudio;
            weatherAudio.loop = true;
            weatherAudio.Play();
        }

        if (weatherAudio.volume < 1 && weatherAudio.clip == overcastAudio)
            weatherAudio.volume += Time.deltaTime * audioFadeTime;
    }

    void SnowWeather()
    {
        Debug.Log("Snow");

        SnowParticles.Play();

        if (Daynight.Day)
        {
            if (sun.intensity > snowIntensity)
                sun.intensity -= Time.deltaTime * lightDimTime;

            if (sun.intensity < snowIntensity)
                sun.intensity += Time.deltaTime * lightDimTime;
        }
        if (weatherAudio.volume > 0 && weatherAudio.clip != snowAudio)
            weatherAudio.volume -= Time.deltaTime * audioFadeTime;

        if (weatherAudio.volume == 0)
        {
            weatherAudio.Stop();
            weatherAudio.clip = snowAudio;
            weatherAudio.loop = true;
            weatherAudio.Play();
        }

        if (weatherAudio.volume < 1 && weatherAudio.clip == snowAudio)
            weatherAudio.volume += Time.deltaTime * audioFadeTime;
    }
}
