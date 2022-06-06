using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletItem : MonoBehaviour
{
    [SerializeField] private AudioSource bulletCollectSFX;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            bulletCollectSFX.Play();
            ammoText.ammoamount += 4;
            Destroy(collision.gameObject);
        }
    }
}
