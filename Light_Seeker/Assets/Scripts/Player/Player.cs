using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int maxArmor = 100;
    public int currentArmor;
    public ArmorBar armorBar;

    // Start is called before the first frame update
    void Start()
    {
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

        if(currentArmor > 0){
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
        }
    }

    /*
    public void TakeDamage(int damage){
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    */
    
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
