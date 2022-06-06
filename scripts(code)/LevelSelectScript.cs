using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelSelectScript : MonoBehaviour
{
    //Return Main Menu
    public void returnMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Load Tutorial
    public void LoadTutorial()
    {
        SceneManager.LoadScene(2);
    }

    //Load Level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene(3);
    }
}
