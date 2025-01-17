using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections), typeof(Damageable))]

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float jumpImpulse = 10f;
    public float airWalkSpeed = 3f;
    public CoinManager coinManager;
    public int coinCount;

    Vector2 moveInput;
    TouchingDirections touchingDirections;
    Damageable damageable;
    Rigidbody2D rb;
    Animator animator;

    public AudioClip coinSound;
    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                        return walkSpeed;
                    else
                        return airWalkSpeed;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
    }


    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }
    [SerializeField]
    private bool _isMoving = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
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
            animator.SetBool(AnimationStrings.isMoving, value);
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

    private void FixedUpdate()
    {
        if(!damageable.LockVelocity)
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        //coinCount = coinManager.coinCounter;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive)
        {
            IsMoving = moveInput != Vector2.zero;
            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
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

    public void OnJump(InputAction.CallbackContext context)
    {
        //TODO Check if alive as well
        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
            //Debug.Log("cox");
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            coinCount = coinCount + 5;
            GetComponent<AudioSource>().PlayOneShot(coinSound);
            //coinCount = coinManager.coinCounter;
            Destroy(other.gameObject);
        }
    }

}