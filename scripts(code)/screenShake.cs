using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class screenShake : MonoBehaviour
{
    private CinemachineVirtualCamera CMVCam;
    private float shakeTimer;
    public static screenShake Instance { get; private set; }

    private void Start()
    {
        Instance = this;
        CMVCam = GetComponent<CinemachineVirtualCamera>();
    }
    public void shakeCamera(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin CMVCamOPerlin = CMVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        CMVCamOPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }
    private void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin CMVCamOPerlin = CMVCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                CMVCamOPerlin.m_AmplitudeGain = 0f;
            }
        }
    }
}
