using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFin : MonoBehaviour

{

    public void Start(){
        Cursor.lockState = CursorLockMode.None;

    }

    public void LoadMenu() {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        {
            Debug.Log("SALIR");
            Application.Quit();
        }
    }


}


