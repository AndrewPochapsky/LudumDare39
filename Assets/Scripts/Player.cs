using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

    Rigidbody2D rb;
    public float thrust;
    [SerializeField]
    private Vector2 maxVelocity;

    public float fireRate;
    private float nextFire;
    private float damage = 8;

    private AudioSource audioSource;

    [SerializeField]
    private Transform exit;

    Transform leftWall, rightWall;

    private KeyCode abductKey = KeyCode.Space;
    
    [HideInInspector]
    public AbductionBeam beam;

    private KeyCode? previousMovementKey = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        beam = transform.GetChild(0).GetComponent<AbductionBeam>();
        audioSource = GetComponent<AudioSource>();

        rightWall = GameObject.FindGameObjectWithTag("RightWall").transform;
        leftWall = GameObject.FindGameObjectWithTag("LeftWall").transform;
    }

    // Use this for initialization
    void Start ()
    {
        //default is 1000
        MaxPower = 500;
        CurrentPower = MaxPower;
	}
	
	// Update is called once per frame
	protected override void Update ()
    {
        base.Update();

        //print("player power: " + CurrentPower);
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, leftWall.position.x + 2, rightWall.position.x - 2),transform.position.y);

        if (Input.GetKeyDown(abductKey) && !beam.Abducting)
        {
            rb.velocity = Vector2.zero;
            beam.Abduct();
        }
        else if (Input.GetKeyUp(abductKey))
        {
            beam.StopAbduct();
        }

        DrainPowerOverTime();

        if (Input.GetMouseButton(0) && !beam.Abducting)
        {
            Fire();
        }

    }
    private void FixedUpdate()
    {
        if (!beam.Abducting)
        {
            Move();
        }
        
        //print("velocity: " + rb.velocity);
        

    }

    public void IncreaseDamage(float value)
    {
        damage += value;
    }

    public void IncreaseSpeed(float value)
    {
        maxVelocity += new Vector2(value, value);
        print("new speed: " + maxVelocity);
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
    

    public void IncreasePower(float currentPower, float maxPower)
    {
        CurrentPower += currentPower;

        MaxPower += maxPower;

        if(CurrentPower > MaxPower)
        {
            float diff = CurrentPower - MaxPower;
            CurrentPower -= diff;
        }
    }

    private void DrainPowerOverTime()
    {
        CurrentPower -= 0.75f * Time.deltaTime;
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

    private void Fire()
    {
        if(Time.time > nextFire)
        {
            GameObject laser = Instantiate(Resources.Load("Laser"), exit.position, exit.rotation) as GameObject;

            audioSource.Play();

            laser.GetComponent<Laser>().Damage = damage;

            nextFire = Time.time + fireRate;
        }
    }

    public override void Die()
    {
        GameManager.finalDamage = damage;
        GameManager.finalMaxPower = MaxPower;

        GameObject.FindObjectOfType<LevelManager>().LoadLevel("End");

        base.Die();
    }


}
