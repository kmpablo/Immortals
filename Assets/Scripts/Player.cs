using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth;
    public int maxMana;
    public int currentHealth;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    public bool battleMode = true; // we can eventually have the movement script inherit this bool to check for current phase

    void Start()
    {
        maxHealth = 1000;
        healthBar.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);

        maxMana = 10000;
        manaBar.setMaxMana(maxMana);
        currentMana = maxMana;
        manaBar.setMana(currentMana);
    }

    void Update()
    {
        // random tests
        if (battleMode){
            takeDamage(1);
            spendMana(5);
        }
    }

    void takeDamage(int damage){
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);
    }

    void spendMana(int cost){
        currentMana -= cost;
        manaBar.setMana(currentMana);
    }
}
