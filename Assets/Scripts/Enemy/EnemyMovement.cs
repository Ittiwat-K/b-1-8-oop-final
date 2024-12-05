using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyMovement : CharacterController
{
    private PlayerDetectionController playerDetectionController;
    private Vector2 targetDirection;
    private Animator animator;
    public string targetTag = "Player";

    protected override void Awake()
    {
        base.Awake();
        playerDetectionController = GetComponent<PlayerDetectionController>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateToTarget();
        SetVelocity();
    }

    // update ตำแหน่งของ player
    private void UpdateTargetDirection()
    {
        if (playerDetectionController.DetectionPlayer)
        {
            targetDirection = playerDetectionController.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
        PreventOffScreen(rigidbody.velocity);
    }

    // หันหน้าหา player
    private void RotateToTarget()
    {
        if (targetDirection != Vector2.zero)
        {
            RotateTowards(targetDirection);
        }
    }

    public override void SetVelocity()
    {
        if (targetDirection != Vector2.zero)
        {
            rigidbody.velocity = transform.up * speed;
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }
    }

    // animation เมื่อชนกับ player
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            animator.SetBool("IsCollide", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            animator.SetBool("IsCollide", false);
        }
    }
}
