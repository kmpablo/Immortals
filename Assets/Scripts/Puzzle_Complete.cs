using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Complete : MonoBehaviour
{
    public GameObject finish;
    public GameObject notfinish;
    public void CompletePuzzle()
    {
        notfinish.SetActive(false);
        finish.SetActive(true);
    }
}
