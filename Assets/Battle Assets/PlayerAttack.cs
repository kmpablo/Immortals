using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private bool raised;
    public GameObject shield;
    public int extraDamage;
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.Q].wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            GetComponent<Melee>().AttemptAttack(mousePos, extraDamage, "Damageable"); //play attack animation, use up stamina, etc.
        }
        if (Keyboard.current[Key.C].wasPressedThisFrame /*&& GetComponent<Player>().currentMana > 0.2 * GetComponent<Player>().maxMana*/)
        {
            raised = true;
            shield.SetActive(true);
            Debug.Log("Shield raised");

        } else if (Keyboard.current[Key.C].wasReleasedThisFrame /*|| GetComponent<Player>().currentMana <= 0.2 * GetComponent<Player>().maxMana*/) {
            raised = false;
            shield.SetActive(false);
            Debug.Log("Shield lowered");
        }
        if (raised)
        {
            GetComponent<Player>().spendMana((int)(1500f * Time.deltaTime));
        }
    }
}