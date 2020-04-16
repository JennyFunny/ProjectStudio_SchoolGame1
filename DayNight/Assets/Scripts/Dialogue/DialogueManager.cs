using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DialogueManager : MonoBehaviour {

    GameObject dBox;
    TextMeshProUGUI dText;
    GameObject questionBox;

    [HideInInspector]
    public bool dialogActive;

    public string [] dialogLines;
    public int currentLine;

    private PlayerMovement thePlayer;

    [HideInInspector]
    public bool isQuestion = false;
    [HideInInspector]
    public bool isYes = false;

    private void Awake()
    {
        @thePlayer = FindObjectOfType<PlayerMovement>();
        @dBox = GameObject.FindWithTag("Dialogue Box");
        @dText = GameObject.FindWithTag("Dialogue Text").GetComponent<TextMeshProUGUI>();
        @questionBox = GameObject.FindWithTag("Dialogue Question");

        @dBox.SetActive(false);
        @questionBox.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space) && !isQuestion && !isYes)
        {
            currentLine++;
        }
        else if(dialogActive && Input.GetKeyDown(KeyCode.Space) && !isQuestion && isYes)
        {
            currentLine += 2;
        }

        if (currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogActive = false;
            currentLine = 0;
            thePlayer.canMove = true;
        }
        dText.text = dialogLines[currentLine]; 

        if(dBox.activeSelf)
        {
            isYes = false;
        }
    }

    public void ShowBox(string dialogue)
    {
        dialogActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }

    public void ShowQuestion()
    {
        dialogActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
        questionBox.SetActive(true);
    }

    public void Answer(bool answer)
    {
        if (answer)
        {
            currentLine = 1;
            dialogLines[2] = dialogLines[1];
            isYes = true;
        }
        else
        {
            currentLine = 2;
            isYes = false;
        }
        isQuestion = false;
        questionBox.SetActive(false);
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("QuizNiels");
    }
}
