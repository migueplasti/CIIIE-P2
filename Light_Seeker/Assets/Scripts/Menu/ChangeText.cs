using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeText : MonoBehaviour
{
    public Text changeText;
    //public GameObject changeTextTo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextChange();
    }

    public void TextChange(){
        if(SceneManager.GetActiveScene().buildIndex == 1){
            changeText.text = "Encuentra refugio";
            //changeTextTo.GetComponent<Text>().text = "Encuentra refugio";
        }else if(SceneManager.GetActiveScene().buildIndex == 2){
            changeText.text = "Huye a las montañas";
            //changeTextTo.GetComponent<Text>().text = "Huye del reino";
        }
    }

}
