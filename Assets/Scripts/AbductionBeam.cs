using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbductionBeam : MonoBehaviour {

    private Entity target;

    [SerializeField]
    private float abductionSpeed;

    private bool _abducting = false;

    private SpriteRenderer sp;
    //private BoxCollider2D boxCol;

    public bool Abducting {
        get
        {
            return _abducting;
        }
    }

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        //boxCol = GetComponent<BoxCollider2D>();

        sp.enabled = false;
        //boxCol.enabled = false;
    }

    private void Update()
    {
        if (target != null)
            print("not null");
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
            targetRb.isKinematic = true;

            targetRb.velocity = new Vector2(0, abductionSpeed);
        }
       

    }

    public void StopAbduct()
    {
        //boxCol.enabled = false;
        sp.enabled = false;

        if (target != null)
        {
            Rigidbody2D targetRb = target.GetComponent<Rigidbody2D>();

            //targetRb.AddForce(transform.up * abductionSpeed);
            targetRb.isKinematic = false;

            targetRb.velocity = Vector2.zero;
        }


        _abducting = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print(collision.name);

        if (collision.GetComponent<Entity>() && target == null)
        {
            target = collision.GetComponent<Entity>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //print(collision.name);

        if (collision.GetComponent<Entity>() && target != null)
        {
            Entity entity = collision.GetComponent<Entity>();

            if (target.Equals(entity))
            {
                target = null;
            }
        }
    }


}
