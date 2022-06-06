using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehavior : MonoBehaviour
{
    public float moveSpeed;
    public Collider2D bullet;
    public Collider2D turn;
    public Transform bulletPrefab;



    Rigidbody2D rb;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<Collider2D>();
        turn = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(bullet, turn, true);

    }


    void Update()
    {
        if( isFacedRight()) //Face left or Right
        {
            rb.velocity = new Vector2(moveSpeed, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, 0f);
        }
    }
    private bool isFacedRight()
    {
        return transform.localScale.x > Mathf.Epsilon; //Checks is transform X is greater than lowest possible number.
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); //EXECUTES if Collider EXITS
    }
}
