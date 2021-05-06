using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Rigidbody mybody;
    bool hit = false;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody>();
    }
        IEnumerator DestroyArrow()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
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
            collision.collider.GetComponent<EnemyStats>().RecieveDamage(damage);
            GetComponent<Rigidbody>().isKinematic=true; // stop physics
        }

        if (collision.collider.tag == "Shield"){
            GetComponent<Rigidbody>().isKinematic=true; // stop physics
        }
        transform.parent = collision.transform;
        hit = true;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
