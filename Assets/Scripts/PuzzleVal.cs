using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleVal : MonoBehaviour
{
    //public int[] password = { 1, 2, 3, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    public int size = 16;
    public GameObject[] puzzles;
    bool solved = false;
    //public Puzzle_script[] puzzles;
    // Start is called before the first frame update
    void Start()
    {
        puzzles = new GameObject[size];
        // puzzles = FindObjectsOfType<Puzzle_script>();
        for (int i = 0; i < size; i++)
        {
            puzzles[i] = GameObject.Find("Piece_" + i);
        }
    }
    public void ValidatePuzzle()
    {
        Debug.Log("validating!");
        bool completed = true;
        for (int i = 0; i < size; i++)
        {
            Puzzle_script attempt = puzzles[i].GetComponent<Puzzle_script>();

            if (attempt.getPosition() != 1)
            {
                completed = false;
                // Debug.Log(i);
                // Debug.Log(pw[i]);
                //  Debug.Log(attempt.getPosition());
                Debug.Log("validation not successful!");
            }

        }
        if (completed)
        {
            Debug.Log("validation succesful!");
            solved = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (solved)
        {
            Debug.Log("Open!");
            transform.parent.GetComponent<Puzzle_Complete>().CompletePuzzle();
            solved = false;
        }
    }
}
