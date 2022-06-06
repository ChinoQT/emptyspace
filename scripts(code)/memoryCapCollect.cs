using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class memoryCapCollect : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Capsule"))
        {
            Destroy(collision.gameObject);
            memCapUI.OBJcap += 1;
            if(memCapUI.OBJcap == 2)
            {
                finishPT.Instance.spawnFinish();
            }
        }
    }
}
