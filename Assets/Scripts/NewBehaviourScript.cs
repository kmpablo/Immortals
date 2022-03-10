using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    bool raised;
    void Start()
    {
        raised = false;
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp("e"))
        {
            raised = !raised;
            if (raised)
            {
                Debug.Log("Shield raised");
            }
            else
            {
                Debug.Log("Shield lowered");
            }
        }
    }
}
