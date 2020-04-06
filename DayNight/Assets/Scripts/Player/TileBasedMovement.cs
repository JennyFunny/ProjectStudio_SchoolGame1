using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileBasedMovement : MonoBehaviour
{
    public Vector2 pos;
    public Vector2 NextPos;
    Vector3 change;
    public float speed = 2.0f;
    public float walklength = 1;
    SpriteRenderer sprite;
    Animator anim;
    Rigidbody2D rb;

    public bool canMove = true;
    public float collisiontimer;
    // House entries ////////////////////////////////////////////////////////////////
    private static bool playerExists;
    public string startPoint;
    // House entries ////////////////////////////////////////////////////////////////
    // Start is called before the first frame update


    void Awake()
    {
        collisiontimer = 1;
        pos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        NextPos = transform.position;

        // House entries ////////////////////////////////////////////////////////////////
        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                speed += 0.1f;
            }
            if (Input.GetKey(KeyCode.X))
            {
                speed = 1f;
            }
            if (Input.GetKey(KeyCode.W))
            {

                NextPos = new Vector2(this.transform.position.x, this.transform.position.y + walklength);


            }
            if (Input.GetKey(KeyCode.A))
            {
                NextPos = new Vector2(this.transform.position.x - walklength, this.transform.position.y);

            }
            if (Input.GetKey(KeyCode.S))
            {
                NextPos = new Vector2(this.transform.position.x, this.transform.position.y - walklength);

            }
            if (Input.GetKey(KeyCode.D))
            {
                NextPos = new Vector2(this.transform.position.x + walklength, this.transform.position.y);

            }

            if (canMove)
            {
                change.x = Input.GetAxisRaw("Horizontal");
                change.y = Input.GetAxisRaw("Vertical");

                if (change != Vector3.zero)
                {
                    anim.SetFloat("MoveX", change.x);
                    anim.SetFloat("MoveY", change.y);
                    anim.SetBool("moving", true);

                }
                else
                {
                    anim.SetBool("moving", false);
                }
            }
            if (change != Vector3.zero)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector2.MoveTowards(this.transform.position, NextPos, step);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.gameObject.tag == "Collider")
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(this.transform.position, pos, step);
            Debug.Log("do");
        }
    }

}
