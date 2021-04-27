using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealObject : MonoBehaviour
{
    int health = 10;



    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player"){
            print("collided");

            Player player = collider.gameObject.GetComponent<Player>();

            player.Heal(health);

            Destroy(gameObject);



        }
        
    }
}
