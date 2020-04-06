using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockadeManager : MonoBehaviour
{

    public static bool town1 = false;
    public static bool town2 = false;
    public bool route2 = false;
    public GameObject gm;
    Scene currentscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gm = GameObject.Find("GameManager");
        currentscene = SceneManager.GetActiveScene();
        if (town1 && currentscene.name == "Tiled")
        {
            if (town1 == true)
            {
                Destroy(FindObjectOfType<Blockade>().gameObject);
                town1 = false;
            }
        }   
        if(town2 && currentscene.name == "ArtistTown")
        {
            Destroy(FindObjectOfType<Blockade>().gameObject);
        }
        if (gm.GetComponent<GameManager>().gerard == true && currentscene.name == "Route2")
        {

          Destroy(GameObject.Find("blockade"));
        }
    }

    public void Yes()
    {
        Destroy(FindObjectOfType<Blockade>().gameObject);
        checktown();
    }

    void checktown()
    {
        if(currentscene.name == "Tiled")
        {
            town1 = true;
        }else if(currentscene.name == "ArtistTown")
        {
            town2 = true;
        }
    }
}
