using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float attackRadius;
    public float damage;

    // Update is called once per frame
    void Update()
    {

        
        if (Keyboard.current[Key.Q].wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            GetComponent<Melee>().AttemptAttack(mousePos, damage, attackRadius, "Damageable"); //play attack animation, use up stamina, etc.
        }
    }
}