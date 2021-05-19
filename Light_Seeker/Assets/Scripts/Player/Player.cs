using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int maxArmor = 100;
    public int currentArmor;
    public ArmorBar armorBar;
    private AudioSource audioSource;
    public AudioClip [] sounds;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        currentArmor = maxArmor;
        armorBar.SetMaxArmor(maxArmor);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Keypad0)){
            TakeDamage(20);
            TakeArmorDamage(20);
        }
        
    }

    public void TakeDamage(int damage){
        AudioClip hitSound = sounds[1];
        AudioClip deathSound = sounds[0];
    
        if(currentArmor > 0){
            AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position);
            if(currentArmor - damage >= 0){
                currentArmor -= damage;
                armorBar.SetArmor(currentArmor);
            }else{
                currentHealth = (currentHealth + currentArmor) - damage;
                currentArmor = 0;
                healthBar.SetHealth(currentHealth);
                armorBar.SetArmor(currentArmor);
            }
        }else{
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            if(currentHealth <= 0){
                //sonido
                AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
                //muere y manda al menu
                SceneManager.LoadScene (sceneBuildIndex: 0);
            } else {
                AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position);
            }
        }
    }

    public void TakePenDamage(int damage){
        AudioClip hitSound = sounds[1];
        AudioClip deathSound = sounds[0];
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth <= 0){
            //sonido
            AudioSource.PlayClipAtPoint(deathSound, this.gameObject.transform.position);
            //muere y manda al menu
            SceneManager.LoadScene (sceneBuildIndex: 0);
        } else {
            AudioSource.PlayClipAtPoint(hitSound, gameObject.transform.position);
        }
    }
    
    public void Heal(int heal){
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    public void HealArmor(int healArmor){
        currentArmor += healArmor;
        armorBar.SetArmor(currentArmor);
    }

    public void TakeArmorDamage(int damage){
        currentArmor -= damage;
        armorBar.SetArmor(currentArmor);
    }
}
