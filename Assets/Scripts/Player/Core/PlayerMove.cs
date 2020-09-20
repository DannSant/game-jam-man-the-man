using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Config variables
    [SerializeField] float runSpeed = 40f;
    [SerializeField] UITest ui;

    //References
    CharController2D controller;
    
    //State variables
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    
    
    void Start()
    {
        controller = GetComponent<CharController2D>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;            
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }

        if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            ui.ToggleWindow();
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;




    }
   
    //private void FixedUpdate()
    //{
    //    controller.Move(horizontalMove*Time.fixedDeltaTime, crouch, jump);
    //    jump = false;
    //}
}
