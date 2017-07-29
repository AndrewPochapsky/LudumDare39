using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    Player target;

    [SerializeField]
    private Transform exit;

    public float fireRate, minDistance;
    private float nextFire;





	// Use this for initialization
	void Start () {
        target = GameObject.FindObjectOfType<Player>(); 
	}
	
	// Update is called once per frame
	void Update () {
        LookAtTarget();
        Fire();
	}

    private void LookAtTarget()
    {
        Vector2 dir = target.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }


    private void Fire()
    {
        if (PlayerInRange())
        {
            if (Time.time > nextFire)
            {
                Instantiate(Resources.Load("Missile"), exit.position, exit.rotation);

                nextFire = Time.time + fireRate;
            }
        }
       
        
    }

    private bool PlayerInRange()
    {

        return Vector2.Distance(transform.position, target.transform.position) <= minDistance;
    }



}
