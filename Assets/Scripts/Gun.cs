using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    Transform target;

    Transform humanParent;
    SpriteRenderer sp;
    Transform blast;

    AudioSource audioSource;

    public float damage;

    bool attacking = false;

    public Sprite gun1Main, gun1Blast, gun2Main, gun2Blast;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindObjectOfType<Player>().transform;
        humanParent = transform.parent;
        blast = transform.GetChild(0);
	}
	
	// Update is called once per frame
	void Update () {
        LookAtPlayer();
        //TODO refactor this gross stuff
        if (!humanParent.GetComponent<ArmyHuman>().GettingAbducted && !humanParent.GetComponent<ArmyHuman>().Dead)
        {
            Animator parentAnim = humanParent.gameObject.GetComponent<Animator>();
            if (humanParent.GetComponent<ArmyHuman>().Firing && !attacking)
            {
                parentAnim.SetBool("isFiring", true);
                StartCoroutine(Fire(target.GetComponent<Entity>()));
                blast.gameObject.SetActive(true);
            }
            else if (!humanParent.GetComponent<ArmyHuman>().Firing)
            {
                StopAllCoroutines();
                parentAnim.SetBool("isFiring", false);
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
            blast.localPosition = new Vector2(-2.79f, 0.487f);
        }
        else if(humanParent.eulerAngles.y==180)
        {
            sp.sprite = gun2Main;
            blast.localPosition = new Vector2(2.79f, 0.487f);

        }

        Quaternion rotation = Quaternion.LookRotation
            (target.transform.position - transform.position, transform.TransformDirection(Vector3.up));

        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }

    private IEnumerator Fire(Entity target)
    {
        attacking = true;
        audioSource.Play();
        yield return new WaitForSeconds(1.5f);
        target.DealDamage(damage);
        StartCoroutine(Fire(target));

    }


}
