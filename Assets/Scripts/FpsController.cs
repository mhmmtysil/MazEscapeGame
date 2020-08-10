using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public Rigidbody rb;
    public float cameraRotationSpeed = 5f;
    public float rotationSmoothSpeed = 10f;
    public float walkSpeed = 15f;
    private GameObject collisionWith;
    float bodyRotationX;
    float camRotationY;
    float speed;
    public int lenght;
    private int counter;
    [HideInInspector]
    public Joystick joystick;
    public Vector3 startingPos;
    private Animator anim;
    public void Initialize()
    {
        transform.position = startingPos;
    }
    void Start()
    {
        anim = GetComponent<Animator>();
        joystick = GameObject.FindGameObjectWithTag("PlayerMover").GetComponent<Joystick>();
        startingPos = transform.position;
    }

    void Update()
    {
       // LookRotation();
        Movement();
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.CompareTag("SpeedUp"))
        {
            SoundConfiguration.Instance.PlaySpeedSound();
            collisionWith = c.gameObject;
            Destroy(collisionWith.gameObject);
            walkSpeed += 1;
        }

    }

    public void StageController(){
        counter += 1;
        if (counter >= GameConfiguration.Instance.letters.Count) {
            counter = 0;
            GameConfiguration.Instance.StageCompleted();
        }
    }
    void Movement()
    {
        //Change our characters velocity in this direction
        rb.velocity = new Vector3(joystick.Horizontal * speed, rb.velocity.y, joystick.Vertical * speed); //transform.forward * joystick.Vertical * speed + transform.right * joystick.Horizontal * speed + transform.up * rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, walkSpeed);
        if(joystick.InRect)
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, transform.eulerAngles.z);
        speed = walkSpeed;
        if(joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetFloat("speed", 1);
        }
        else
        {
            anim.SetFloat("speed", 0);
        }
    }
}
