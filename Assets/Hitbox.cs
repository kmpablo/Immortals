using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay2D(Collision2D other)
    {
        // Debug.Log("test");
        ContactPoint2D contactPoint = other.GetContact(0);
        Vector2 pt = contactPoint.point;
        
        if (other.gameObject.tag == "Weapon" && other.gameObject.transform.parent.GetComponent<Melee>().attackMode)
        {
            damage = other.gameObject.GetComponent<Weapon>().damage;
            Vector2 userPos = other.gameObject.GetComponent<Weapon>().user.transform.position;
            RaycastHit2D hit = Physics2D.Raycast(userPos, pt - userPos);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                if (tag == "Player")
                {
                    //GetComponent<Player>().takeDamage(damage);
                    Debug.Log("Player just took " + damage + " damage from " + other.gameObject.tag);
                    other.gameObject.transform.parent.GetComponent<Melee>().attackMode = false;

                } else if (tag == "Damageable")
                {
                    //GetComponent<Enemy>().takeDamage();
                    Debug.Log("Enemy just took " + damage + " damage from " + other.gameObject.tag);
                    other.gameObject.transform.parent.GetComponent<Melee>().attackMode = false;
                }
            }
        }
    }
}
