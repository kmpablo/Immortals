using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public GameObject weapon;
    public int manaCost;
    public bool attackMode;
    public bool alreadyHit;
    private float cooldown;

    void Start()
    {
        attackMode = false;
        alreadyHit = false;
    }

    void Update()
    {
        if (attackMode)
        {
            cooldown += Time.deltaTime;
            if (cooldown > 1)
            {
                attackMode = false;
            }
        }
    }
    public void AttemptAttack(Vector3 dir, int extraDamage, string targetTag)
    {
        if (!attackMode)
        {
            if (tag == "Player")
            {
                if (GetComponent<Player>().currentMana - manaCost >= 0)
                {
                    GetComponent<Player>().spendMana(manaCost); //dummy value
                } else {
                    return;
                }
            }
            alreadyHit = false;
            Debug.Log(tag + " attempting attack towards " + dir);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            weapon.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            weapon.GetComponent<Weapon>().dest = weapon.GetComponent<Weapon>().start + Vector3.Normalize(dir);
            weapon.GetComponent<Weapon>().ThrustWeapon();
            weapon.GetComponent<Weapon>().damage += extraDamage;
            attackMode = true;
            cooldown = 0;
        }
    }


    public void Attack(Vector2 dir, int damage, GameObject target)
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
