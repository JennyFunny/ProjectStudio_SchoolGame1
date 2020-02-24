using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoadCanvas : MonoBehaviour
{
    private static DontDestroyOnLoadCanvas playerInstance;
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
