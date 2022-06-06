using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public static int points = 0;
    [SerializeField] private Text melonTxt;
    [SerializeField] private AudioSource itemCollectSFX;
    private void Update()
    {
        melonTxt.text = "" + points;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon")) //IF PLAYER COLLIDE TO OBJECT WITH TAG Melon => EXECUTE
        {
            itemCollectSFX.Play();
            Destroy(collision.gameObject);
            points += 10;
            melonTxt.text = "" + points; //update UI
        }
    }
}
