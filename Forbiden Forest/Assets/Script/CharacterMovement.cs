using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Camera myCamera;
    CharacterController controller;
    public float speed = 5;
    public float SprintingSpeed = 8;
    float DesRotation = 0f;
    public float JumpSpeed = 2f;
    float DesAnimationSpeed = 0f;
    public float RotationSpeed = 15;
    public float AnimationBlendSpeed = 2f;
    Animator myAnimator;
    bool Sprinting = false;
    bool Jumping = false;
    float SpeedY = 0;
    float Gravity = -9.81f;
    public static CharacterMovement instance;
    private void Start()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
        myAnimator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            speed = 45;
            
        }

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }

        }

        DontDestroyOnLoad(gameObject);

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
       if(Input.GetButtonDown("Jump") && !Jumping)
        {
            Jumping = true;
            myAnimator.SetTrigger("Jump");

            SpeedY += JumpSpeed;
        }
        if (!controller.isGrounded)
        {
            SpeedY += Gravity * Time.deltaTime;
        }
        else if (SpeedY < 0)
        {
            SpeedY = 0;
        }
        myAnimator.SetFloat("mSpeedY", SpeedY / JumpSpeed);
        if(Jumping && SpeedY < 0)
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position, Vector3.down, out hit, .5f, LayerMask.GetMask("Default")))
            {
                Jumping = false;
                myAnimator.SetTrigger("Land");
            }
        }

        Sprinting = Input.GetKey(KeyCode.LeftShift);
        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
        

        Vector3 rotatedMovement = Quaternion.Euler(0, myCamera.transform.rotation.eulerAngles.y, 0) * movement;
        Vector3 verticalMovement = Vector3.up * SpeedY;

        // using ternaly
        controller.Move((verticalMovement + (rotatedMovement * (Sprinting ? SprintingSpeed : speed))) * Time.deltaTime);

        if(rotatedMovement.magnitude > 0)
        {
            DesRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
            DesAnimationSpeed = Sprinting ? 1 : .5f;

        }else
        {
            DesAnimationSpeed = 0;
        }
        myAnimator.SetFloat("Speed", Mathf.Lerp(myAnimator.GetFloat("Speed"), DesAnimationSpeed, AnimationBlendSpeed * Time.deltaTime));
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, DesRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, RotationSpeed * Time.deltaTime);



        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }
    
    public void Attack()
    {
        myAnimator.SetTrigger("Attack1");
    }



}
  


