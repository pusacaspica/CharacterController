using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform turnable;
    public float velocity = 2f;
    public List<Camera> cameras;
    public float roll = 10.0f;
    public float jumpSpeed, maxGravity, deltaGravity, upperRotationLimit, lowerRotationLimit;

    private Animator anim;
    private float mouseX, mouseY, mousePosX, mousePosY, gravity, rotY;
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        gravity = 0.0f;
        characterController = this.GetComponent<CharacterController>();
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;
        rotY = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        //if(characterController.isGrounded){

            mouseX = Input.mousePosition.x - mousePosX;
            rotY += Input.GetAxis("Mouse Y") * roll;
            rotY = Math.Clamp(rotY, lowerRotationLimit, upperRotationLimit);
            //mouseY = Input.mousePosition.y - mousePosY;
            this.transform.Rotate(0, mouseX*roll*Time.deltaTime, 0);
            turnable.localEulerAngles = new Vector3(rotY, turnable.localEulerAngles.y, turnable.localEulerAngles.z);
            //turnable.Rotate(-mouseY*roll*Time.deltaTime, 0, 0);

            moveDirection *= velocity;

            if(Input.GetButton("Jump") && characterController.isGrounded){
                moveDirection.y += jumpSpeed;
            }

            mousePosX = Input.mousePosition.x;
            //mousePosY = Input.mousePosition.y;

            if(!characterController.isGrounded) gravity += deltaGravity;
            else gravity = 0.0f;
            //if(gravity > 0.0f) gravity = 0.0f;
        /*} else {
            if(gravity < maxGravity) gravity += deltaGravity;
        }*/

        moveDirection.y -= gravity * Time.deltaTime;

        moveDirection = transform.TransformDirection(moveDirection);

        characterController.Move(moveDirection * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Tab)){
            if(cameras[0].gameObject.activeSelf){
                cameras[0].gameObject.SetActive(false);
                cameras[1].gameObject.SetActive(true);
            } else {
                cameras[1].gameObject.SetActive(false);
                cameras[0].gameObject.SetActive(true);
            }
        }

    }
}
