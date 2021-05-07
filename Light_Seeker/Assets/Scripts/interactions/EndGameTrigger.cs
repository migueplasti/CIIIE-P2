using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameTrigger : MonoBehaviour
{
    // Start is called before the first frame update
  void OnTriggerEnter(Collider collider) {

      if (collider.gameObject.tag == "Player"){
          Debug.Log("End game");
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

      }

  }


}
