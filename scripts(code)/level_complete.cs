using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class level_complete : MonoBehaviour
{

    private AudioSource completeSound;
    private bool levelCompleted = false;
    public GameObject LevelCompleteUI;

    void Start()
    {
        completeSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !levelCompleted)
        {
            completeSound.Play();
            levelCompleted = true;
            Invoke("completeLVL", 1f);


        }
    }
    public void completeLVL()
    {
        PauseMENU.Instance.finishLevel();
    }
    
}
