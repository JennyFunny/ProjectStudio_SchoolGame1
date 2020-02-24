using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mailbox : MonoBehaviour
{

    DialogueHolder dialogue;

    bool isAcitve = true;
    Scene currentScene;


    void Awake()
    {
        dialogue = GetComponent<DialogueHolder>();
    }

    private void Update()
    {
         currentScene = SceneManager.GetActiveScene();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isAcitve)
        {
            if (collision.tag == "Player")
            {
                print("hello there");
                if (Input.GetKey(KeyCode.E))
                    dialogue.ShowDialogueQuestionMailbox();

                
                if (dialogue.isYes)
                {
                    if (currentScene.name == "Tiled")
                        GameManager.urenverantwoordingPalletTown = true;
                    if (currentScene.name == "ArtistTown")
                        GameManager.urenverantwoordingArtistTown = true;

                    Destroy(this);

                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (dialogue.isYes)
            dialogue.isYes = false;
    }
}
