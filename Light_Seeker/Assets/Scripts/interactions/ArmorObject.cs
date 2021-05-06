using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorObject : MonoBehaviour
{
    int armor = 30;
    private AudioSource sound;
    

    void Start() {
        sound = gameObject.GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player"){
            print("collided");

            Player player = collider.gameObject.GetComponent<Player>();

            if (player.currentArmor < player.maxArmor){
                player.HealArmor(armor);
                AudioSource.PlayClipAtPoint(sound.clip, gameObject.transform.position);
                Destroy(gameObject);
            }




        }
        
    }
}
