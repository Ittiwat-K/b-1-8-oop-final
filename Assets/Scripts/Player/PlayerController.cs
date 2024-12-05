using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : CharacterController
{
    [SerializeField] private float smoothTime = 0.1f;
    private Vector2 movementInput;
    private Vector2 smoothMovementInput;
    private Vector2 smoothMovementInputVelocity;
    private Animator animator;

    // method overriding ???
    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        SetVelocity();
        RotateInDirectionOfInput();
        SetAnimation();
        MouseInput();
    }

    // abstract override
    public override void SetVelocity()
    {
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, movementInput, ref smoothMovementInputVelocity, smoothTime);
        rigidbody.velocity = smoothMovementInput * speed;
        PreventOffScreen(rigidbody.velocity);
    }

    // player หมุนทิศทางตาม input ของการเคลื่อนไหว
    private void RotateInDirectionOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            RotateTowards(movementInput);
        }
    }

    // animation เมื่อ player เคลื่อนไหว
    private void SetAnimation()
    {
        bool isMoving = movementInput != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);
    }

    // player รับ input การหันจาก mouse
    private void MouseInput()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rigidbody.position;
        RotateTowards(aimDirection);
    }

    // player รับ input การเคลื่อนไหวจาก keyboard
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
