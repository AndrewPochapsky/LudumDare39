using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float speed = 3;
    public float damage = 5;


    Player player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindObjectOfType<Player>();	
	}
	 
	// Update is called once per frame
	void Update () {
        LookAtTarget();
        MoveTowardsTarget();
	}

    private void LookAtTarget()
    {
        Vector2 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void MoveTowardsTarget()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


}
