using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    int health = 30;
    private AudioSource sound;


    void Start() {
        sound = gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player"){
            print("collided");

            Player player = collider.gameObject.GetComponent<Player>();

            if (player.currentHealth < player.maxHealth){
                player.Heal(health);
                AudioSource.PlayClipAtPoint(sound.clip, gameObject.transform.position);
                Destroy(gameObject);
            }




        }
        
    }
}
