using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class OptionsVolume : MonoBehaviour
{

    public AudioMixer audioMixer;
    public float mouseSens = 100f;
    public void SetVolume (float volume){
        audioMixer.SetFloat("volume", volume);
    }

    public void sensitivity(float sens){
        mouseSens = sens;

        
    }
    
}
