using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemyParent;
    public GameObject player;
    
    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        maxHealth = 100;
        healthBar.setMaxHealth(maxHealth);
        currentHealth = maxHealth;
        healthBar.setHealth(currentHealth);
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
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
        if (currentHealth <= 0){
            Destroy(enemyParent);
            Destroy(gameObject);
        }
        healthBar.setHealth(currentHealth);
    }
}
