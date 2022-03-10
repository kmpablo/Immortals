using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapePanel : MonoBehaviour
{
    public EscapeMenu escapeMenu;

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");    
    }

    public void CloseMenu()
    {
        escapeMenu.gameObject.SetActive(false);
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            escapeMenu.gameObject.SetActive(!escapeMenu.gameObject.activeSelf);
        }
    }
}
