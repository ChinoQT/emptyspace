using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class memCapUI : MonoBehaviour
{
    Text text;
    public static int OBJcap = 0;
    void Start()
    {
        text = GetComponent<Text>();
    }

    void Update()
    {
        if (OBJcap > 0)
        {
            text.text = OBJcap + "/2";
            
        }
        else
        {
            text.text = "0/2";
        }
    }
}
