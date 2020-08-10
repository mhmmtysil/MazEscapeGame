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
    private bool tracked = false;
    public bool Tracked { get => tracked; set => tracked = value; }
    void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("CameraMover").GetComponent<Joystick>();
        cam = GetComponent<CinemachineVirtualCamera>();
        compos = cam.GetCinemachineComponent<CinemachineComposer>();
    }
    void LateUpdate()
    {
        yOffset = joystick.Horizontal * smoothRot;
        //compos.m_TrackedObjectOffset.x = yOffset;
        if (!Tracked)
        {
            GameObject o = GameObject.FindGameObjectWithTag("Player");
            if (o != null)
            {
                player = o.transform;
            }
        }
        if(player != null && !Tracked)
        {
            cam.Follow = player;
            cam.LookAt = player;
            Tracked = true;
        }
    }

    
}
