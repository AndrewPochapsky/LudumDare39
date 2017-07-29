using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    Transform target;

    Transform humanParent;
    SpriteRenderer sp;
    Transform blast;

    public float damage;

    bool attacking = false;

    public Sprite gun1Main, gun1Blast, gun2Main, gun2Blast;

	// Use this for initialization
	void Start () {
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindObjectOfType<Player>().transform;
        humanParent = transform.parent;
        blast = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        LookAtPlayer();
        if (!humanParent.GetComponent<ArmyHuman>().GettingAbducted)
        {
            if (humanParent.GetComponent<ArmyHuman>().Firing && !attacking)
            {
                StartCoroutine(Fire(target.GetComponent<Entity>()));
                blast.gameObject.SetActive(true);
            }
            else if (!humanParent.GetComponent<ArmyHuman>().Firing)
            {
                StopAllCoroutines();
                blast.gameObject.SetActive(false);
                attacking = false;
            }
        }
        else
        {
            StopAllCoroutines();
            blast.gameObject.SetActive(false);
            attacking = false;
        }
        
	}

    private void LookAtPlayer()
    {
        if (humanParent.eulerAngles.y == 0)
        {
            sp.sprite = gun1Main;
            blast.localPosition = new Vector2(-3.85f, 0.7f);
        }
        else if(humanParent.eulerAngles.y==180)
        {
            sp.sprite = gun2Main;
            blast.localPosition = new Vector2(3.85f, 0.7f);

        }

        Quaternion rotation = Quaternion.LookRotation
            (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));

        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private IEnumerator Fire(Entity target)
    {
        attacking = true;
        yield return new WaitForSeconds(2);
        target.DealDamage(damage);
        StartCoroutine(Fire(target));

    }


}
