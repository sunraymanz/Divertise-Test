using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController2D controlToken;
    [SerializeField] float runSpeed;
    [SerializeField] float horizontalValue;
    [SerializeField] Animator animToken;
    bool isJump;
    // Start is called before the first frame update
    void Start()
    {
        controlToken = GetComponent<CharacterController2D>();
        animToken = GetComponentInChildren<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        CheckKeyPress();
        UpdateAnimation();
    }

    private void FixedUpdate()
    {
        controlToken.Move(horizontalValue * Time.fixedDeltaTime, isJump);
        isJump = false;
    }

    void CheckKeyPress() 
    { 
        //check if jump
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }
        //check if walk
        horizontalValue = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    void UpdateAnimation()
    {
        animToken.SetFloat("Xspeed", horizontalValue);
        animToken.SetFloat("Yspeed", GetComponent<Rigidbody2D>().velocity.y);
        animToken.SetBool("OnGround", GetComponent<CharacterController2D>().m_Grounded);
        animToken.SetBool("IsWalk", Input.GetButton("Horizontal"));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Interactable>())
        {
            collision.gameObject.GetComponentInParent<Interactable>().ShowIcon();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Interactable>())
        {
            collision.gameObject.GetComponentInParent<Interactable>().HideIcon();
        }
    }
}
