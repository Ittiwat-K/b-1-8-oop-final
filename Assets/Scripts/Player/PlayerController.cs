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

    public override void SetVelocity()
    {
        smoothMovementInput = Vector2.SmoothDamp(smoothMovementInput, movementInput, ref smoothMovementInputVelocity, smoothTime);
        rigidbody.velocity = smoothMovementInput * speed;
        PreventOffScreen(rigidbody.velocity);
    }

    private void RotateInDirectionOfInput()
    {
        if (movementInput != Vector2.zero)
        {
            RotateTowards(movementInput);
        }
    }

    private void SetAnimation()
    {
        bool isMoving = movementInput != Vector2.zero;
        animator.SetBool("IsMoving", isMoving);
    }

    private void MouseInput()
    {
        Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDirection = mousePosition - rigidbody.position;
        RotateTowards(aimDirection);
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }
}
