using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static float worldTime = 15;

    public bool playTime = true;

    [HideInInspector]
    public static bool urenverantwoordingPalletTown = false;
    [HideInInspector]
    public static bool urenverantwoordingArtistTown = false;

    private static GameManager Instance;

    [SerializeField]
    float timeSpeed = 1;

    void Awake()
    {
        DontDestroyOnLoad(this);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (playTime)
        {
            worldTime += 1 * timeSpeed * Time.deltaTime;
            if (worldTime >= 23)
            {
                worldTime = 0;
            }
        }

        Scene currentScene = SceneManager.GetActiveScene();
        if (urenverantwoordingPalletTown && currentScene.name == "Tiled")
        {
            GameObject.FindObjectOfType<Blockade>().gameObject.SetActive(false);
        }
        if(urenverantwoordingArtistTown && currentScene.name == "ArtistTown")
        {
            GameObject.FindObjectOfType<Blockade>().gameObject.SetActive(false);
        }
    }
}
