using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text2 : MonoBehaviour
{
    List<string> secondchoice = new List<string>() { "Renkema", "perron 4¾", "Ja, 3 jaar", "Varken met aardapel op zn hoofd", "fifth" };
    // Start is called before the first frame update
    void Start()
    {
       // GetComponent<TextMesh>().text = secondchoice[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        if (textcontrol.randQuestion > -1)
        {
            GetComponent<TextMesh>().text = secondchoice[textcontrol.randQuestion];
        }
    }

    void OnMouseDown()
    {
        textcontrol.selectedAnswer = gameObject.name;
        textcontrol.choiceSelected = "y";
    }
}
