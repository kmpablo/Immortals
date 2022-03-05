using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextTrigger : MonoBehaviour
{
    public Text Txt;

    public void changeText()
    {
        transform.parent.GetComponent<TextDisplay>().changeDisplay(Txt);
        Debug.Log("changed!");
    }
}
