using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blockade : MonoBehaviour
{
    DialogueHolder dialogue;
    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        dialogue = GetComponent<DialogueHolder>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            dialogue.ShowDialogue();
            anim.enabled = true;
        }
    }
}
