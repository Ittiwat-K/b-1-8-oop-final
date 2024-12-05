using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] Transform bulletOffset;
    [SerializeField] private float timeBetweenShots;
    private bool isFireContinuously;
    private bool isFireSingle;
    private float lastFireTime;

    // Check the player's firing type.
    void Update()
    {
        if (isFireContinuously || isFireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime; 
            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireBullet();
                lastFireTime = Time.time;
                isFireSingle = false;
            }
        }
    }

    // Build ammo and shoot.
    private void FireBullet()
    {
        GameObject _bullet = Instantiate(bullet, bulletOffset.position, transform.rotation);
        Rigidbody2D rigidbody = _bullet.GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.up * bulletSpeed;
    }

    // Check the player's pressed fire button?
    private void OnFire(InputValue inputValue)
    {
        isFireContinuously = inputValue.isPressed;
        if (inputValue.isPressed)
        {
            isFireSingle = true;
        }
    }
}
