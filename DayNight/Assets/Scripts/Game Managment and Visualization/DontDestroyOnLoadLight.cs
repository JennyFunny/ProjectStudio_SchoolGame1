using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadLight : MonoBehaviour
{
    private static DontDestroyOnLoadLight playerInstance;
    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
