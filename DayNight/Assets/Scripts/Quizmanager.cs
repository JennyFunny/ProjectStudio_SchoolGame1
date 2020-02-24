using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Quizmanager : MonoBehaviour
{

    public TextMeshProUGUI questionHolder;
    public TextMeshProUGUI[] Answers;
    public TextMeshProUGUI Controle;
    // Start is called before the first frame update
    void Start()
    {
        Controle.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Correct()
    {
        Controle.text = "Correct";
        Controle.color = Color.green;
    }

    public void Wrong()
    {
        Controle.text = "Fout";
        Controle.color = Color.red;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
