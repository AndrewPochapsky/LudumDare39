using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    public float speed = 10;
    private float damage;

    public float Damage
    {
        get
        {
            return damage;
        }

        set
        {
            damage = value;
        }
    }

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
                if (mb is ScienceHuman || mb is RegularHuman)
                    damageable.DealDamage(Damage * 100);
                else
                    damageable.DealDamage(Damage * 2);
            }
        }
        Destroy(gameObject);
    }

}
