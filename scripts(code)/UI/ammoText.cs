using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ammoText : MonoBehaviour
{
    Text text;
    public static int ammoamount = 0;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (ammoamount > 0)
        {
            text.text = "Energy: " + ammoamount;
        }
        else
        {
            text.text = "Out of Energy";
        }
    }
}
