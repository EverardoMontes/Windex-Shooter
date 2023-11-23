using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float speed = 3f;
    private Rigidbody2D playerRb;
    private Vector2 moveInput;
    private Boolean run;
    public static PlayerMovement instance;
    public float moveX;
    public float moveY;
    public float saludPersonaje;
    private Text puntaje;
    private Boolean Verpuntaje;

    private void Awake()
    {
        instance = this;
    }

    [Header("Animacion")]
    private Animator animator;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
       // puntaje = GameObject.Find("Puntos").GetComponent<Text>();
        //puntaje.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        run = Input.GetKey(KeyCode.LeftShift);
        
        Verpuntaje = Input.GetKey(KeyCode.Tab);
        moveInput = new Vector2(moveX, moveY).normalized;
        animator.SetFloat("horizontal", Math.Abs(moveX));
        animator.SetFloat("vertical", Math.Abs(moveY));
        //playerAnimator.SetFloat("horizontal", moveX);
        //playerAnimator.SetFloat("vertical", moveY);
        //playerAnimator.SetFloat("speed", moveInput.sqrMagnitude);
        
    }

    private void FixedUpdate()
    {
        //if (Verpuntaje)
        //{
          //  puntaje.enabled = true;
        //}
        //else
        //{
          //  puntaje.enabled = false;
        //}

            if (run == true)
        {
            playerRb.MovePosition(playerRb.position + moveInput *speed * 5/3 * Time.fixedDeltaTime);
        }
        else
        {
            playerRb.MovePosition(playerRb.position + moveInput * speed *Time.fixedDeltaTime);
        }
        }


}
