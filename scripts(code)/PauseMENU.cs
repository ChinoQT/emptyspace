using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMENU : MonoBehaviour
{
    public static bool gamePaused = false;
    public GameObject finishLevelUI;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    public static PauseMENU Instance { get; private set; }
    private void Start()
    {
        Instance = this;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape)) //FOR DEV ONLY
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; 
        gamePaused = false;
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePaused = true;
    }
    public void returnMenuLevel1()
    {
        PlayerLIFE.restartStats();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void finishLevel()
    {
        finishLevelUI.SetActive(true);
    }
}
