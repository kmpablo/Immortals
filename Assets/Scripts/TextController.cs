using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject textbox;

    public void turnOn()
    {
        if (textbox.activeSelf)
            textbox.SetActive(false);
        else
            textbox.SetActive(true);
    }

}
