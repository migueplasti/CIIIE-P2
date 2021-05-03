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

    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            transform.rotation = Quaternion.LookRotation(mybody.velocity);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy"){
            collision.collider.GetComponent<EnemyStats>().RecieveDamage(damage);
        }
        hit = true;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
