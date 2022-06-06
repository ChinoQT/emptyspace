using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPade : MonoBehaviour
{
    public float jumpFrc = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpFrc,ForceMode2D.Impulse);
            PlayerMovement.canDoubleJump = true;
        }
    }
}
