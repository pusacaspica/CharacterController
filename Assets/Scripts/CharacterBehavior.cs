using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public float inputH, inputV;
    public Animator anim;
    public CharacterController characterController;
    private float elapsedTime, gravity;
    private bool running;

    // Start is called before the first frame update
    void Start()
    {
        running = false;
        gravity = 9.802f;
        elapsedTime = 0.0f;
        anim = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        running = (Input.GetKey(KeyCode.LeftShift) ? true : false);
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal") * (running ? 3.0f : 1.0f), 0.0f, Input.GetAxis("Vertical") * (running ? 3.0f : 1.0f));

        inputH = Input.GetAxis("Horizontal");
        inputV = Input.GetAxis("Vertical");

        elapsedTime += Time.deltaTime;
        anim.SetFloat("elapsedTime", elapsedTime);
        if(elapsedTime > 60f) elapsedTime = 0.0f;

        if(Input.GetMouseButtonDown(0)){
            int n = Random.Range(0, 2);
            if(n == 0)
                anim.Play("DAMAGED00", -1, 0f);
            else
            {
                anim.Play("DAMAGED01", -1, 0f);
            }
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("Jump");
        }
        anim.SetBool("walking", (inputH != 0f || inputV != 0f) ? true : false);
        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        anim.SetBool("running", running);

        //moveDirection.y -= gravity * Time.deltaTime;

        moveDirection = transform.TransformDirection(moveDirection);

        characterController.Move(moveDirection * Time.deltaTime);
    }
}
