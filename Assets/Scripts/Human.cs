using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : Entity {

    public enum HumanType { Regular, Special, Army }

    public float Speed { get; protected set; }

    public HumanType Type { get; protected set; }

    protected Rigidbody2D rb;

    Vector3 direction;

    protected bool isGrounded = false;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating("ChooseDirection", 0, 1);
    }

    protected virtual void FixedUpdate()
    {
        if (isGrounded)
        {
            Move();
        }
    }

    protected virtual void Move()
    {
         rb.MovePosition(transform.position + -transform.right * Speed * Time.deltaTime); 
    }

    protected virtual void ChooseDirection()
    {
        int randNum = Random.Range(0, 2);

        if(randNum == 0)
        {
            //direction =  Vector3.right;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            //direction =  Vector3.left;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
