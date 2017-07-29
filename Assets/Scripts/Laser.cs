using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 5;
    public float damage = 4;

	// Use this for initialization
	void Start () {
        SetRotation();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }


    private void SetRotation()
    {
        Vector3 destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 dir = destination - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        MonoBehaviour[] list = collision.gameObject.GetComponents<MonoBehaviour>();
        foreach (var mb in list)
        {
            if (mb is IDamageable)
            {
                IDamageable damageable = (IDamageable)mb;
                damageable.DealDamage(damage);
            }
        }
        Destroy(gameObject);
    }

}
