﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    Rigidbody2D rb;
    public float thrust;
    public Vector2 maxVelocity;

    Transform leftWall, rightWall;

    private KeyCode abductKey = KeyCode.Space;
    

    public AbductionBeam beam;

    private KeyCode? previousMovementKey = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        beam = transform.GetChild(0).GetComponent<AbductionBeam>();

        rightWall = GameObject.FindGameObjectWithTag("RightWall").transform;
        leftWall = GameObject.FindGameObjectWithTag("LeftWall").transform;
    }

    // Use this for initialization
    void Start ()
    {
        MaxPower = 100;
        CurrentPower = MaxPower;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftWall.position.x + 2, rightWall.position.x - 2),transform.position.y);

        if (Input.GetKeyDown(abductKey) && rb.velocity == Vector2.zero && !beam.Abducting)
        {
            beam.Abduct();
        }
        else if (Input.GetKeyUp(abductKey))
        {
            beam.StopAbduct();
        }

        DrainPowerOverTime();
        //print("Power: " + CurrentPower);
	}
    private void FixedUpdate()
    {
        if (!beam.Abducting)
        {
            Move();
        }
        
        //print("velocity: " + rb.velocity);
        

    }

    protected void Move()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (previousMovementKey == KeyCode.A)
                {
                    ResetVelocity();
                    
                }
                previousMovementKey = KeyCode.D;

                if (!ExceedsMaxVelocity())
                {
                    rb.AddForce(transform.right * thrust);
                }

            }
           
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (previousMovementKey == KeyCode.D)
                {
                    ResetVelocity();
                    
                }
                previousMovementKey = KeyCode.A;

                if (!ExceedsMaxVelocity())
                {
                    rb.AddForce(-transform.right * thrust);
                }
            }
            
        }
        else 
        {
            SlowDown();

        }

    }

    private void SlowDown()
    {
        Vector2 currentVelocity = rb.velocity;
        Vector2 oppositeForce = -currentVelocity * 4;

        float roundedXVelocity = Mathf.Abs(Mathf.Round(rb.velocity.x));

        //add opposing force to slow down the player
        if (roundedXVelocity > 0)
        {
            rb.AddRelativeForce(oppositeForce, ForceMode2D.Force);
        }
        else if (roundedXVelocity == 0)
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void ResetVelocity()
    {
        rb.velocity = Vector2.zero;
        
    }

    private bool ExceedsMaxVelocity()
    {
        return (Mathf.Abs(rb.velocity.x) > maxVelocity.x);
    }
    

    public void IncreasePower(float power)
    {
        CurrentPower += power;
        print("increasing power");
        if(CurrentPower > MaxPower)
        {
            float diff = CurrentPower - MaxPower;
            CurrentPower -= diff;
        }
    }

    private void DrainPowerOverTime()
    {
        CurrentPower -= 0.5f * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Missile>())
        {
            Missile missile = collision.GetComponent<Missile>();
            print("hitting");
            DealDamage(missile.damage);

            Destroy(missile.gameObject);
        }
    }



}
