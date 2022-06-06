using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject prefabBullet;
    [SerializeField] private AudioSource gunSFX;
    public float timeLimit;
    private void Start()
    {
        timeLimit = 0.3f;
    }
    void Update()
    {
        timeLimit -= Time.deltaTime;
        if (CrossPlatformInputManager.GetButtonDown("ShootBTN") && ammoText.ammoamount > 0 && timeLimit <= 0) //SHOOT Button on UI
        {

            screenShake.Instance.shakeCamera(5f, .3f);
            timeLimit = 0.8f;
            gunSFX.Play();
            Shoot();
            ammoText.ammoamount -= 1;
        }
    }

    void Shoot()
    {
        Instantiate(prefabBullet, firePoint.position, firePoint.rotation);
    }
}
