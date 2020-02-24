using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlockadeManager : MonoBehaviour
{

    static bool town1 = false;
    static bool town2 = false;

    Scene currentscene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentscene = SceneManager.GetActiveScene();
        if (town1 && currentscene.name == "Tiled")
        {
            Destroy(FindObjectOfType<Blockade>().gameObject);
        }
        if(town2 && currentscene.name == "ArtistTown")
        {
            Destroy(FindObjectOfType<Blockade>().gameObject);
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
