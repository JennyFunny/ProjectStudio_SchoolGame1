using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizHolder : MonoBehaviour
{
    public string question;
    public string answer1;
    public string answer2;
    public string answer3;
    public string answer4;

    public Quizmanager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager.questionHolder.text = question;
        manager.Answers[0].text = answer1;
        manager.Answers[1].text = answer2;
        manager.Answers[2].text = answer3;
        manager.Answers[3].text = answer4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
