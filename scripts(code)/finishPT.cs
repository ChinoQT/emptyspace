using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishPT : MonoBehaviour
{
    public Transform finishSpawn;
    public GameObject prefabFinish;
    public static finishPT Instance { get; private set; }
    void Start()
    {
        Instance = this;
        
    }

    public void spawnFinish()
    {
        Instantiate(prefabFinish, finishSpawn.position, finishSpawn.rotation);
    }
}
