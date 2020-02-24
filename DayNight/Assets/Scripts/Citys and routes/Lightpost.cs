using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightpost : MonoBehaviour
{
    public Color lampAlpha;

    GameObject[] Lanterns;
    GameObject[] Flares;

    // Update is called once per frame
    void Update()
    {
        Lanterns = GameObject.FindGameObjectsWithTag("Lantaarn");
        Flares = GameObject.FindGameObjectsWithTag("Flare");

        if (GameManager.worldTime > 20 || GameManager.worldTime < 6)
        {
            EnableLanterns();
        }
        else if(GameManager.worldTime > 6 || GameManager.worldTime < 20)
        {
            DisableLanterns();
        }
        
        if(GameManager.worldTime > 20 || GameManager.worldTime < 5)
        {
            if (lampAlpha.a < 0.8f)
            {
                lampAlpha.a += 0.8f * Time.deltaTime;
            }
        }
        else if(GameManager.worldTime > 5 || GameManager.worldTime < 20)
        {
            if (lampAlpha.a > 0)
            {
                lampAlpha.a -= 0.8f * Time.deltaTime;
            }
        }

        for (int i = 0; i < Flares.Length; i++)
        {
            Flares[i].GetComponent<SpriteRenderer>().color = lampAlpha;
        }
    }

    void DisableLanterns()
    {
        for (int i = 0; i < Lanterns.Length; i++)
        {
            Lanterns[i].gameObject.SetActive(false);
        }
    }

    void EnableLanterns()
    {
        for (int i = 0; i < Lanterns.Length; i++)
        {
            Lanterns[i].gameObject.SetActive(true);
        }
    }
}
