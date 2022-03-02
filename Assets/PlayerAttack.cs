using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public float damage;

    // Update is called once per frame
    void Update()
    {

        
        if (Keyboard.current[Key.Q].wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            GetComponent<Melee>().AttemptAttack(mousePos, damage, "Damageable"); //play attack animation, use up stamina, etc.
        }

                if(Keyboard.current[Key.W].isPressed)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Time.deltaTime * 2);
        }
        else if(Keyboard.current[Key.A].isPressed)
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime * 2, transform.position.y);
        }
        else if(Keyboard.current[Key.D].isPressed)
        {
            transform.position = new Vector2(transform.position.x + Time.deltaTime * 2, transform.position.y);
        }
        else if(Keyboard.current[Key.S].isPressed)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - Time.deltaTime * 2);
        }


    }
}