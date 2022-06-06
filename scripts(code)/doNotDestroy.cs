using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doNotDestroy : MonoBehaviour
{

    public void Awake()
    {
        GameObject[] musicOBJ = GameObject.FindGameObjectsWithTag("MainMusic");
        if (musicOBJ.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    private void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Level 1")
        {
            Destroy(this.gameObject);
        }
        else if (sceneName == "Tutorial Level")
        {
            Destroy(this.gameObject);
        }
    }
}
