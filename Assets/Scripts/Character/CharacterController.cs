using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// คลาสแม่ของ PlayerController กับ EnemyMovement
// abstract class
public abstract class CharacterController : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected float rotationSpeed;
    [SerializeField] protected float screenBorder;
    protected Rigidbody2D rigidbody;
    protected Camera camera;

    protected virtual void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        camera = Camera.main;
    }

    // ป้องกันตัวละครหลุดขอบจอ
    protected void PreventOffScreen(Vector2 velocity)
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if ((screenPosition.x < screenBorder && velocity.x < 0) || (screenPosition.x > camera.pixelWidth - screenBorder && velocity.x > 0))
        {
            velocity.x = 0;
        }

        if ((screenPosition.y < screenBorder && velocity.y < 0) || (screenPosition.y > camera.pixelHeight - screenBorder && velocity.y > 0))
        {
            velocity.y = 0;
        }

        rigidbody.velocity = velocity;
    }

    // การหันหน้าของตัวละคร
    protected void RotateTowards(Vector2 direction)
    {
        if (direction != Vector2.zero)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            float smoothRotationSpeed = 5f;
            float currentRotation = Mathf.LerpAngle(rigidbody.rotation, angle, smoothRotationSpeed * Time.deltaTime);
            rigidbody.rotation = currentRotation;
        }
    }

    // abstract method 
    public abstract void SetVelocity();
}
