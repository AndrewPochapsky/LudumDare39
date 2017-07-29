using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionBeam : MonoBehaviour {

    public Entity target;

    [SerializeField]
    private float abductionSpeed;

    private bool _abducting = false;

    private SpriteRenderer sp;
    private BoxCollider2D boxCol;

    public bool Abducting {
        get
        {
            return _abducting;
        }
    }

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        boxCol = GetComponent<BoxCollider2D>();

        sp.enabled = false;
        //boxCol.enabled = false;
    }

    private void Update()
    {
        if (Abducting)
        {
            print("abducting");
        }
    }

    public void Abduct()
    {
        _abducting = true;

        //boxCol.enabled = true;
        sp.enabled = true;

        if(target != null)
        {
            Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();

            //targetRb.AddForce(transform.up * abductionSpeed);
            print("target not null and abducting");

            targetRb.isKinematic = true;

            targetRb.velocity = new Vector2(0, abductionSpeed);
            target.GettingAbducted = true;

            //boxCol.enabled = false;
        }
       

    }

    public void StopAbduct()
    {
        //boxCol.enabled = false;
        sp.enabled = false;

        if (target != null)
        {
            Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();

            print("stop abduct");

            //targetRb.AddForce(transform.up * abductionSpeed);
            targetRb.isKinematic = false;

            targetRb.velocity = Vector2.zero;

            target.GettingAbducted = false;
           
        }

        target = null;
        _abducting = false;
        //boxCol.enabled = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //print(collision.name);

        if (collision.GetComponent<Entity>() && target == null)
        {
            target = collision.GetComponent<Entity>();
        }
    }
    /*
    private void OnTriggerExit2D(Collider2D collision)
    {
        //print(collision.name);

        if (collision.GetComponent<Entity>() && target != null)
        {
            Entity entity = collision.GetComponent<Entity>();

            if (target.Equals(entity))
            {
                target.GettingAbducted = false;
                target = null;
            }
        }
    }*/


}
