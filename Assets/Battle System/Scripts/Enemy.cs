using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth;
    public int maxMana;
    public int currentHealth;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    void Start()
    {
        maxHealth = 100;
        healthBar.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);

        maxMana = 500;
        manaBar.setMaxMana(maxMana);
        currentMana = 0;
        manaBar.setMana(currentMana);
    }

    void Update()
    {
        // random tests
        if(currentMana++ == maxMana){
            currentMana = 0;
        } 
        manaBar.setMana(currentMana);
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0){
            Destroy(gameObject);
        }
        healthBar.setHealth(currentHealth);
    }
}
