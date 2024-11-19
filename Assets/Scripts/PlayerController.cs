using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;

    Rigidbody2D rb;
    Animator animator;
    
    public float CurrentMoveSpeed
    {
        get
        {
            if (IsMoving)
                return walkSpeed;
            else
                return 0;
        }
    }

    [SerializeField]
    private bool _isMoving = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    public bool _isFacingRight = true;
   
    public bool IsFacingRight { 
        get 
        { 
            return _isFacingRight; 
        }
        private set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    //[SerializeField]
    //private bool _isRunning = false;

    //public bool IsRunning
    //{
    //    get
    //    {
    //        return _isRunning;
    //    }
    //    set
    //    {
    //        _isRunning = value;
    //        animator.SetBool("isRunning", value);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        IsMoving = moveInput != Vector2.zero;
        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        { 
            //Face the right
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)
        { 
            //Face the left
            IsFacingRight = false;
        }
    }

    //public void OnRun(InputAction.CallbackContext context)
    //{
    //    if (context.started)
    //    {
    //        IsRunning = true;
    //    }
    //    else if (context.canceled)
    //    {
    //        IsRunning = false;
    //    }
    //}
}