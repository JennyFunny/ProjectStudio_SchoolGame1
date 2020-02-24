using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textcontrol : MonoBehaviour
{

    List<string> questions = new List<string>() { "Wat is de achternaam van Niels?", "Wat is het adres van de Rock?", "Kan je de opleiding versnelt doen? Zoja hoeveel jaar duurt het dan?", "Who is this pokemon?!","This is the fifth question" };

    List<string> correctAnswer = new List<string>() { "2", "1", "2", "4", "3" };

    public Transform resultObj;

    public static string selectedAnswer;

    public static string choiceSelected = "n";

    public static int randQuestion = -1;

    public int catMod = 0;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<TextMesh>().text = questions[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (randQuestion == -1)
        {
            randQuestion = Random.Range(0, 4);
        }
        if (randQuestion > -1)
        {
            GetComponent<TextMesh>().text = questions[randQuestion];
        }
        
       // Debug.Log(questions[randQuestion]);
       if (choiceSelected == "y")
        {
            choiceSelected = "n";

            if (correctAnswer[randQuestion] == selectedAnswer)
            {
                Debug.Log("correct!"+"  "+ randQuestion);
                resultObj.GetComponent<TextMesh>().text = "Correct!";             }
        }
    }
}
