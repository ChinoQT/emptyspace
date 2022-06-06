using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLIFE : MonoBehaviour
{
    [SerializeField] private AudioSource deathSFX;
    private Animator anim;
    private Rigidbody2D rb;
    public Image[] souls;
    public int life; //SOULS
    private Transform player;
    [SerializeField] public GameObject entrancePortal;
    public GameObject deathPopup;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        life = souls.Length;
        player = GetComponent<Transform>();
        player.position = new Vector2(entrancePortal.transform.position.x, entrancePortal.transform.position.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("trap")) //If Player Collide to Object with trap TAG => EXECUTE
        {
            screenShake.Instance.shakeCamera(8f, .5f);
            deathSFX.Play();
            Die();
        }
    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static; //SET RIGIDBODY to Static so Player can't move while death.
        anim.SetTrigger("trigger_DEATH"); //Death animation.
        life -= 1; //Minus 1 Life 
    }

    public void respawn()
    {
        if (life > 0) //If number of lives is greater than 0
        {
            anim.SetTrigger("Respawn");
            player.position = new Vector2(entrancePortal.transform.position.x, entrancePortal.transform.position.y); //TP to respawn
            rb.bodyType = RigidbodyType2D.Dynamic; //SET BACK TO DYNAMIC SO PLAYER CAN MOVE UPON RESPAWN
        }
        else
        {
            deathPopup.SetActive(true);
            //restartLVL();
            //ItemCollector.points = 0; //Restart points.
        }
    }

    private void Update() //CHECK PER FRAME THE AMOUNT OF LIFE
    {
        for (int i = 0; i < souls.Length; i++)
        {
            if (i < life)
            {
                souls[i].enabled = true;
            }
            else
            {
                souls[i].enabled = false;
            }
        }
    }
    public static void restartStats()
    {
        ammoText.ammoamount = 0;
        ItemCollector.points = 0;
        memCapUI.OBJcap = 0;
    }

    public void restartLVL()
{
        Time.timeScale = 1f;
        restartStats();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
