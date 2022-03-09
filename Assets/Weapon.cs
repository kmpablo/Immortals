using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public GameObject user;
    private bool currentlyThrusting;
    private bool currentlyThrustingForward;
    public Vector3 start;
    public Vector3 dest;

    void Start()
    {
        currentlyThrusting = false;
        currentlyThrustingForward = false;
        start = transform.localPosition;
        dest = start;

    }

    void Update()
    {
        if (currentlyThrusting)
        {
            if (currentlyThrustingForward)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, dest, Time.deltaTime * 2);
            } else {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, start, Time.deltaTime * 2);
                if(transform.localPosition == start)
                {
                    currentlyThrusting = false;
                }
            }
            if (transform.localPosition == dest)
            {
                currentlyThrustingForward = false;
            }
        }
    }

    public void ThrustWeapon()
    {
        if (!currentlyThrusting)
        {
            currentlyThrusting = true;
            currentlyThrustingForward = true;
        }
    }
    // Start is called before the first frame update

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
}
