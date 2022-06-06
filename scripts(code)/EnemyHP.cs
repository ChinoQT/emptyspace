using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int enmHealth = 100;
    public GameObject deathEffect;

    public void takeDamage(int damage)
    {
        
        enmHealth -= damage;
        if (enmHealth <= 0)
        {
            ItemCollector.points += 15;
            Die();
        }
    }
    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
