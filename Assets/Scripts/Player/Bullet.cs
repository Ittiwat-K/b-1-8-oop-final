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

    // Ŵ���ʹ enemy ��з���µ�� bullet ����ͻз�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyMovement>())
        {
            HealthController healthController = collision.GetComponent<HealthController>();
            healthController.TakeDamage(10);
            Destroy(gameObject);
        }
    }

    // ����µ�� bullet �������ش�ͺ��
    private void DestroyWhenOffScreen()
    {
        Vector2 screenPosition = camera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > camera.pixelWidth || screenPosition.y < 0 || screenPosition.y > camera.pixelHeight)
        {
            Destroy(gameObject);
        }
    }
}
