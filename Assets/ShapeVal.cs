using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShapeVal : MonoBehaviour
{
    private bool solved;
    public int shapes;

    private int shapesCorrect;
    // Start is called before the first frame update
    void Start()
    {
        shapesCorrect = 0;
    }

    // Update is called once per frame

    public void validateShapes()
    {
        shapesCorrect++;
        if (shapesCorrect == shapes)
            solved = true;
    }
    void Update()
    {
        if (solved)
        {
            Debug.Log("Open!");
            solved = false;
        }
    }
}
