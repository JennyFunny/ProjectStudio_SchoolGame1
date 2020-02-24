using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

    public string exitPoint;

    private PlayerMovement thePlayer;
    Scene currentscene;

    Animator anim;

    // Use this for initialization
    void Awake () {
        thePlayer = FindObjectOfType<PlayerMovement>();
        currentscene = SceneManager.GetActiveScene();

        anim = GameObject.FindGameObjectWithTag("fade").GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            anim.SetTrigger("fade");
            SceneManager.LoadScene(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
