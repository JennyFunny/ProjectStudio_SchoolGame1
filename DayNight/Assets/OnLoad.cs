﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnLoad : MonoBehaviour
{
    PlayerMovement player;
    static Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Route1")
        {
            player.canMove = true;
        }
        else
        {
            player.canMove = false;
        }
        print(player.GetComponent<PlayerMovement>().canMove);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
