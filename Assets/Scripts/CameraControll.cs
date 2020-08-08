using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [HideInInspector]
    public Joystick joystick;
    public float yOffset = 0;
    public float smoothRot = 5f;
    private Transform player = null;
    CinemachineVirtualCamera cam;
    CinemachineComposer compos;
    void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("CameraMover").GetComponent<Joystick>();
        cam = GetComponent<CinemachineVirtualCamera>();
        compos = cam.GetCinemachineComponent<CinemachineComposer>();
    }
    void LateUpdate()
    {
        if(player != null)
        {
            cam.Follow = player;
            cam.LookAt = player;
        }
        yOffset = joystick.Horizontal * smoothRot;
        compos.m_TrackedObjectOffset.x = yOffset;

        GameObject o = GameObject.FindGameObjectWithTag("Player");
        if (o != null)
            player = o.transform;
    }
}
