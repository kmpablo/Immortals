using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puzzle_script : MonoBehaviour
{
    // Start is called before the first frame update

    public int position;


    void Start()
    {
        position = 1;
        Debug.Log("Puzzle initiated");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int getPosition()
    {
        return position;
    }

    void OnMouseDown()
    {
        position = position % 4 + 1;
        int angle = (position - 1) * 90;
        transform.eulerAngles = new Vector3(0, 0, angle);
        Debug.Log("Puzzle rotated");
        transform.parent.GetComponent<PuzzleVal>().ValidatePuzzle();
    }
}
