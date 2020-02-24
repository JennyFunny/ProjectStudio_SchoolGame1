using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public Vector3 pos;
    Vector3 change;
    public float speed = 2.0f;

    SpriteRenderer sprite;
    Animator anim;
    Rigidbody2D rb;

    public bool canMove = true;

    // House entries ////////////////////////////////////////////////////////////////
    private static bool playerExists;
    public string startPoint;
    // House entries ////////////////////////////////////////////////////////////////

    void Awake()
    {
        pos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

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
        // House entries ////////////////////////////////////////////////////////////////
    }

    private void Update()
    {
        if (canMove)
        {
            change.x = Input.GetAxisRaw("Horizontal");
            change.y = Input.GetAxisRaw("Vertical");

            if (change != Vector3.zero)
            {
                anim.SetFloat("MoveX", change.x);
                anim.SetFloat("MoveY", change.y);
                anim.SetBool("moving", true);
                MoveCharacter();
            }
            else
            {
                anim.SetBool("moving", false);
            }
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * speed * Time.deltaTime);
    }
}
