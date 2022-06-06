using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            screenShake.Instance.shakeCamera(3f, 1f);
            Invoke("fallPlatform", 1f);
            Destroy(gameObject, 2f);
        }
    }
    void fallPlatform()
    {
        rb.isKinematic = false;
    }
}
