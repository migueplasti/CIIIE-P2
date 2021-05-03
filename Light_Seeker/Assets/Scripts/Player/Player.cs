using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public int maxArmor = 100;
    public double currentArmor;
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
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
    public void Heal(int heal){
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    public void HealArmor(int healArmor){
        currentArmor += healArmor;
        armorBar.SetArmor(currentArmor);
    }

    public void TakeArmorDamage(double damage){
        currentArmor -= damage;
        armorBar.SetArmor(currentArmor);
    }
}
