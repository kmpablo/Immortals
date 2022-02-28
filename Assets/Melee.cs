using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject weapon;
    public bool attackMode;
    private float cooldown;

    void Start()
    {
        weapon.transform.SetParent(transform);
        attackMode = false;
    }

    void Update()
    {
        if (attackMode)
        {
            cooldown += Time.deltaTime;
            if (cooldown == 1)
            {
                attackMode = false;
            }
        }
    }
    public void AttemptAttack(Vector2 dir, float damage, string targetTag)
    {
        Debug.Log(tag + " attempting attack towards " + dir);
        weapon.GetComponent<Weapon>().damage = damage;
        attackMode = true;
        cooldown = 0;
        //code to swing weapon in direction dir

        // RaycastHit2D hit = Physics2D.Raycast(transform.position, dir);
        // if (hit.collider != null && hit.collider.gameObject.tag == targetTag)
        // {
        //     GameObject target = hit.collider.gameObject;
        //     Attack(dir, damage, target);
        // }
    }


    public void Attack(Vector2 dir, float damage, GameObject target)
    {
        if (target.tag == "Damageable")
        {
            Debug.Log("Attacking damageable, " + damage + " damage dealt"); //damageable health is lowered
        }
        if (target.tag == "Player")
        {
            Debug.Log("Attacking player, " + damage + " damage dealt"); //player health is lowered
        }
    }
}
