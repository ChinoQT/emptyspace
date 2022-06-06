using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public float timeLimit;




    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        timeLimit = .6f;
    }
    void Update()
    {
        timeLimit -= Time.deltaTime;
        if (timeLimit <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHP enemy = hitInfo.GetComponent<EnemyHP>();
        if (enemy != null)
        {
            enemy.takeDamage(damage);
            screenShake.Instance.shakeCamera(1f, .1f);
        }
        Destroy(gameObject);
    }
}
