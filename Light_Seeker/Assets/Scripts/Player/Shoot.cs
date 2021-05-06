using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Camera cam;
    public GameObject arrowPrefab;
    public Transform spawn;
    public float power;
    private AudioSource sound;

    void Start() {
        sound = gameObject.GetComponent<AudioSource>();
    }
    
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f)
        {
            GameObject flecha = Instantiate(arrowPrefab, spawn.position, spawn.rotation);
            flecha.GetComponent<Rigidbody>().velocity = cam.transform.forward * 1;
            flecha.GetComponent<Rigidbody>().AddForce(cam.transform.forward * power);
            AudioSource.PlayClipAtPoint(sound.clip, gameObject.transform.position);
        }
    }
}
