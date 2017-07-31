using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyHuman : Human {

    bool firing = false;

    public float minDistance;

    Gun gun;

    private Player player;

    public bool Firing
    {
        get
        {
            return firing;
        }
        protected set
        {
            firing = value;
        }
    }

    // Use this for initialization
    protected override void Start()
    {
        base.Start();
        gun = transform.GetChild(0).GetComponent<Gun>();

        player = GameObject.FindObjectOfType<Player>();

        MaxPower = 25;
        CurrentPower = MaxPower;
        Speed = 2.5f;
    }

   
    private void LateUpdate()
    {
        DirectionRelatingToPlayer();
    }

    protected override void FixedUpdate()
    {
        if (isGrounded)
        {
            if (Vector2.Distance(transform.position, player.transform.position) >= minDistance)
            {
                Move();
                firing = false;
            }
            else
            {
                firing = true;
            }
        }
       
        
    }

    protected override void Move()
    {
        rb.MovePosition(transform.position + -transform.right * Speed * Time.deltaTime);
    }


    private void DirectionRelatingToPlayer()
    {
        float playerX = player.transform.position.x;

        if (playerX > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(playerX < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public override void Die()
    {
        anim.SetBool("Firing", false);
        base.Die();
    }

}
