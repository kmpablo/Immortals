using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimpleAttack : MonoBehaviour
{
    public enum Direction
    {
        Left, 
        Right 
    };
    public float damage;
    public float attackRadius;
    public float attackDelay;
    public GameObject player;
    public Direction facing; //0 is left, 1 is right
    private bool alrInsideRadius;
    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        alrInsideRadius = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alrInsideRadius && Vector2.Distance(player.transform.position, gameObject.transform.position) <= attackRadius)
        {
            dir = player.transform.position - transform.position;
            if ((facing == Direction.Left && dir.x < 0) || (facing == Direction.Right && dir.x > 0))
            {
                InvokeRepeating("RepeatAttemptAttack", 0.5f, attackDelay);
                alrInsideRadius = true;
            }
        }
        if (alrInsideRadius && Vector2.Distance(player.transform.position, gameObject.transform.position) > attackRadius)
        {
            CancelInvoke();
            alrInsideRadius = false;
        }
    }

    void RepeatAttemptAttack()
    {
        GetComponent<Melee>().AttemptAttack(dir, damage, "Player");
    }
}


