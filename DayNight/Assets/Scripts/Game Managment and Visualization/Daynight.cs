using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daynight : MonoBehaviour
{

    public Color nightAmbient;
    Light sun;
    public Color dawnColor;

    static float currentTime;

    public static bool Day;

    // Update is called once per frame

    private void Awake()
    {
        sun = GameObject.FindGameObjectWithTag("Sun").GetComponent<Light>();    
    }

    void Update()
    {
        if(currentTime != GameManager.worldTime)
        {
            print(nightAmbient.a);
            if(currentTime > 18 && currentTime < 23)
            {
                sun.intensity -= 0.15f * Time.deltaTime;
            }
            else if(currentTime > 5 && currentTime < 8)
            {
                sun.intensity += 0.25f * Time.deltaTime;
            }

            if (currentTime > 16 && currentTime < 20)
            {
                sun.color = Color.Lerp(Color.white, dawnColor, 0.5f * Time.deltaTime);
            }

            if(currentTime > 6 && currentTime < 18)
            {
                Day = true;
            }
            else
            {
                Day = false;
            }
        }
        currentTime = GameManager.worldTime;
        print("Opactiy" + nightAmbient.a);
    }
}
