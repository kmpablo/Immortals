using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplay : MonoBehaviour
{
    public Text ogTxt;
    public Text newTxt;

    public void changeDisplay(Text txt)
    {
        ogTxt.text = txt.text;
    }

    public void switchDisplay()
    {
        changeDisplay(newTxt);
    }

}
