using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorObject : MonoBehaviour
{
    int armor = 10;
    



    void OnTriggerEnter(Collider collider) {
        if(collider.gameObject.tag == "Player"){
            print("collided");

            Player player = collider.gameObject.GetComponent<Player>();

            player.HealArmor(armor);

            Destroy(gameObject);



        }
        
    }
}
