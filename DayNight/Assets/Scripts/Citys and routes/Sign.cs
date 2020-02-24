using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : MonoBehaviour
{
    DialogueHolder dialogue;

    private void Awake()
    {
        dialogue = GetComponent<DialogueHolder>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(Input.GetKey(KeyCode.E))
                dialogue.ShowDialogue();
        }
    }
}
