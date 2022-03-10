using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyParent;
    public GameObject player;
    
    public int maxHealth;
    public int maxMana;
    public int currentHealth;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        enemyParent.transform.position = transform.position;
        if (player == null)
        {
            return;
        }
        if (Vector2.Distance(player.transform.position, transform.position) <= 8)
        {
            rb.velocity = new Vector2((player.transform.position.x - transform.position.x)/Mathf.Abs(player.transform.position.x - transform.position.x), 0);
            if (rb.velocity.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                GetComponent<EnemySimpleAttack>().facing = EnemySimpleAttack.Direction.Left;
            } else if (rb.velocity.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                GetComponent<EnemySimpleAttack>().facing = EnemySimpleAttack.Direction.Right;
            }
        }
        // random tests
        // if(currentMana++ == maxMana){
        //     currentMana = 0;
        // } 
        // manaBar.setMana(currentMana);
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        restoreMana(damage * 5);
        if (currentHealth <= 0){
            Destroy(enemyParent);
            Destroy(gameObject);
        }
        healthBar.setHealth(currentHealth);
    }

    void restoreMana(int amount)
    {
        if (currentMana + amount <= maxMana)
        {
            currentMana += amount;
        } else {
            currentMana = maxMana;
        }
        manaBar.setMana(currentMana);
    }
}
