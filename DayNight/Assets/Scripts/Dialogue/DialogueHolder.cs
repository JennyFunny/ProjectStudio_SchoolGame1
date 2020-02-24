using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManager dMAn;

    public string[] dialogueLines;

    [HideInInspector]
    public bool isYes;

    // Use this for initialization
    void Awake()
    {
        dMAn = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        isYes = dMAn.isYes;
    }

    public void ShowDialogue()
    {
        if (!dMAn.dialogActive)
        {
            dMAn.dialogLines = dialogueLines;
            dMAn.currentLine = 0;
            dMAn.ShowDialogue();
        }
    }

    public void ShowDialogueQuestionMailbox()
    {
        if (!dMAn.dialogActive)
        {
            dMAn.dialogLines = dialogueLines;
            dMAn.currentLine = 0;
            dMAn.ShowQuestion();
        }
    }

    
}
