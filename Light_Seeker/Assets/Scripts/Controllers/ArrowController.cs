using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Rigidbody mybody;
    bool hit = false;
    public float damage;

    public float timeToDestroy = 5f;
    private AudioSource  hitShieldSound;

    // Start is called before the first frame update
    void Start()
    {
        hitShieldSound = gameObject.GetComponent<AudioSource>();
        mybody = GetComponent<Rigidbody>();
    }
        IEnumerator DestroyArrow()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);

   
    }

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            transform.rotation = Quaternion.LookRotation(mybody.velocity);
        } else {
            StartCoroutine(DestroyArrow());
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy"){
            collision.collider.GetComponent<EnemyStatsAndAI>().RecieveDamage(damage);
            GetComponent<Rigidbody>().isKinematic=true; // stop physics
        }

        if (collision.collider.tag == "Shield"){
            AudioSource.PlayClipAtPoint(hitShieldSound.clip, gameObject.transform.position);
            GetComponent<Rigidbody>().isKinematic=true; // stop physics
        }
        transform.parent = collision.transform;
        hit = true;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
