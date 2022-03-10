using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject playerParent;

    public int maxHealth;
    public int maxMana;
    public int currentHealth;
    public int currentMana;

    public HealthBar healthBar;
    public ManaBar manaBar;

    public bool battleMode = true; // we can eventually have the movement script inherit this bool to check for current phase
    public ProjectileBehavior ProjectilePrefab;
    public Transform LaunchOffset;

    public float projectileCooldown;
    private Vector2 lookDirection;
    private float lookAngle;

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

        projectileCooldown = 0;
    }

    void Update()
    {
        playerParent.transform.position = transform.position;
        // random tests
        if (battleMode){
            spendMana((int)(-500 * Time.deltaTime));

            if(projectileCooldown > 0){
                projectileCooldown -= Time.deltaTime;   
            }

            if (Keyboard.current[Key.E].wasPressedThisFrame && projectileCooldown <= 0 && currentMana >= 3000) {
                spendMana(3000);
                projectileCooldown = 1f;
                
                lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
                var projectile = Instantiate(ProjectilePrefab, LaunchOffset.position, Quaternion.Euler(0f, 0f, lookAngle));
                Physics2D.IgnoreCollision(projectile.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }
            
            // if(Keyboard.current[Key.W].isPressed) {
            //     transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 2);
            // }
            
            // if(Keyboard.current[Key.A].isPressed) {
            //     transform.position = new Vector2(transform.position.x - Time.deltaTime * 2, transform.position.y);
            //     transform.rotation = Quaternion.Euler(0, 180, 0);
            // }
            
            // if(Keyboard.current[Key.D].isPressed) {
            //     transform.position = new Vector2(transform.position.x + Time.deltaTime * 2, transform.position.y);
            //     transform.rotation = Quaternion.Euler(0, 0, 0);
            // }
            
            // if(Keyboard.current[Key.S].isPressed) {
            //     transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 2);
            // }
        }
    }

    public void takeDamage(int damage){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Destroy(playerParent);
            Destroy(gameObject);
        }
        else if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.setHealth(currentHealth);
    }

    public void spendMana(int cost){
        currentMana -= cost;
        if(currentMana < 0){
            currentMana = 0;
        }
        else if(currentMana > maxMana){
            currentMana = maxMana;
        }
        manaBar.setMana(currentMana);
    }

    public void restoreMana(int amount){
        if (currentMana + amount <= maxMana)
        {
            currentMana += amount;
        } else {
            currentMana = maxMana;
        }
        manaBar.setMana(currentMana);
    }
}
