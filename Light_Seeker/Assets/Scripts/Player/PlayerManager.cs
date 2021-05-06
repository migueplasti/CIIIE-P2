using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;


    void Awake(){
        //Singleton
        if (instance == null)
            instance = this;
        else{
            Destroy(gameObject);
        }
    
    }

    #endregion

    public GameObject player;

}
