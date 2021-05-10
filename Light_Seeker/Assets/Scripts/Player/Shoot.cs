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
    public bool reloading;
    public float reloadTime;
    public float currentReload;

    private Canvas crosshair;

    void Start() {
        sound = gameObject.GetComponent<AudioSource>();
        crosshair = gameObject.GetComponentInChildren<Canvas>();
    }
    
    void Update()
    {
        

        if (Time.timeScale == 0f){
            crosshair.enabled = false;
        }
        else if (crosshair.enabled == false ){
            crosshair.enabled = true;
        }

        if (reloading)
        {
            currentReload = currentReload + Time.deltaTime;
            if (currentReload >= reloadTime)
            {
                reloading = false;
                currentReload = 0f;
            }
        }

        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0f && !reloading)
        {
            GameObject flecha = Instantiate(arrowPrefab, spawn.position, spawn.rotation);
            flecha.GetComponent<Rigidbody>().velocity = cam.transform.forward * 1;
            flecha.GetComponent<Rigidbody>().AddForce(cam.transform.forward * power);
            AudioSource.PlayClipAtPoint(sound.clip, gameObject.transform.position);
            reloading = true;
        }
    }
}
