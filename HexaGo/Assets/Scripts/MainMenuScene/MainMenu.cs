using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartFunction()
    {
        //FEEDBACK: izbjegavati hard kodirane broje, koristiti parametre za loadanje scena
        SceneManager.LoadScene("Level_01");
    }

    public void QuitFunction()
    {
        Application.Quit();
    }
}
