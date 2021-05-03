using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    Rigidbody mybody;
    bool hit = false;

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
        hit = true;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
