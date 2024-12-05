using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Camera camera;

    private void Awake()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        DestroyWhenOffScreen();
    }

    // Reduces enemy health and destroys bullets on impact.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(10);
            Destroy(gameObject);
        }
    }

    // Destroy the bullet when it off the edge of the screen.
    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
