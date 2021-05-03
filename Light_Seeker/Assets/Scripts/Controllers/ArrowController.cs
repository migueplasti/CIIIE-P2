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
        hit = true;
        Destroy(gameObject.GetComponent<Rigidbody>());
    }
}
