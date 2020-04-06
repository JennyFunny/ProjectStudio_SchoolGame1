using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NPCBehavior : MonoBehaviour {

    DialogueHolder dialogue;

    [SerializeField] private float stepsHorizontal;
    [SerializeField] private float stepsVertical;

    [SerializeField] private bool walkHorizontal;
    [SerializeField] private bool walkVertical;

    [SerializeField] private bool isWalking;
    private float steps;
    [SerializeField] private float waitTime;
    private float waitCounter;

    private int WalkDirection;
    private int WalkDir;

    Vector3 pos;
    Vector3 change;
    public float speed = 0.01f;
    public float gridSize = 0.1f;

    public RuntimeAnimatorController mainAnim;
    public RuntimeAnimatorController dernAnim;
    
    SpriteRenderer sprite;
    Animator anim;

    float changeX;
    float changeY;
    
    private DialogueManager dMAn;

    private bool canTalk;
    private bool isTalking;

    // Use this for initialization
    void Awake () {
        pos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        dMAn = FindObjectOfType<DialogueManager>();
        dialogue = GetComponent<DialogueHolder>();

        waitCounter = waitTime;

        ChooseDirection();
    }
	
	// Update is called once per frame
	void Update () {
        walking();
        if (canTalk)
        {
            npcTalk();
        }
        dernEasterEgg();
	}

    // Makes the npc walk in the chosen direction.
    public void walking()
    {
        if (isWalking)
        {
            if (steps > 0)
            {
                anim.SetBool("moving", true);
                if (WalkDirection == 0 && transform.position == pos)
                {
                    pos += Vector3.left * gridSize;
                    steps -= 1;
                    anim.SetFloat("MoveX", -1);
                    anim.SetFloat("MoveY", 0);
                }
                if (WalkDirection == 1 && transform.position == pos)
                {
                    pos += Vector3.up * gridSize;
                    steps -= 1;
                    anim.SetFloat("MoveY", 1);
                    anim.SetFloat("MoveX", 0);
                }
                if (WalkDirection == 2 && transform.position == pos)
                {
                    pos += Vector3.right * gridSize;
                    steps -= 1;
                    anim.SetFloat("MoveX", 1);
                    anim.SetFloat("MoveY", 0);
                }
                if (WalkDirection == 3 && transform.position == pos)
                {
                    pos += Vector3.down * gridSize;
                    steps -= 1;
                    anim.SetFloat("MoveY", -1);
                    anim.SetFloat("MoveX", 0);
                }
                transform.position = Vector3.MoveTowards(transform.position, pos, speed);
            }

            if (steps <= 0)
            {
                steps = 0;
                WalkDirection = 4;
                isWalking = false;
                waitCounter = waitTime;
                anim.SetBool("moving", false);
            }
        }
        else
        {
            if (steps <= 0)
            {
                waitCounter -= Time.deltaTime;
                if (waitCounter < 0)
                {
                    ChooseDirection(); 
                }
            }
        }
    }


    //choose the direction the npc is walking in.
    public void ChooseDirection()
    {
        print("chosing direction");
        if (walkHorizontal && walkVertical){
            switch(WalkDir)
            {
                case 0: WalkDir = 1; WalkDirection = 0; steps = stepsHorizontal; break;
                case 1: WalkDir = 2; WalkDirection = 1; steps = stepsVertical; break;
                case 2: WalkDir = 3; WalkDirection = 2; steps = stepsHorizontal; break;
                case 3: WalkDir = 0; WalkDirection = 3; steps = stepsVertical; break;
            }
        } else if (walkVertical) {
            switch (WalkDir)
            {
                case 0: WalkDir = 1; WalkDirection = 1; steps = stepsVertical; break;
                case 1: WalkDir = 0; WalkDirection = 3; steps = stepsVertical; break;
            }
        }
        else if (walkHorizontal) {
            switch (WalkDir)
            {
                case 0: WalkDir = 1; WalkDirection = 0; steps = stepsHorizontal; break;
                case 1: WalkDir = 0; WalkDirection = 2; steps = stepsHorizontal; break;
            }
        }
        if (steps > 0) {
            isWalking = true;
        }
        
    }

    public void npcTalk()
    {
        if (canTalk)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            if (Input.GetKey(KeyCode.E))
            {
         
                    if (this.gameObject.tag == "Dern")
                    {
                        SceneManager.LoadScene("Dern");
                 }
                if (this.gameObject.tag == "Jasper")
                {
                    SceneManager.LoadScene("Jasper");
                }
                if (this.gameObject.tag == "Gerard")
                {
                    SceneManager.LoadScene("Gerard");
                }
                else
                {
                    if (currentScene.name != "Jasper")
                    {
                        dialogue.ShowDialogue();
                    }
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWalking = false;
            anim.SetBool("moving", false);
            canTalk = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isWalking = true;
            canTalk = false;
        }
    }

    private void dernEasterEgg(){
        if (this.gameObject.tag == "Npc"){
            anim.runtimeAnimatorController = mainAnim;
        }
        if (this.gameObject.tag == "Dern"){
            anim.runtimeAnimatorController = dernAnim;
        }
    }
}
