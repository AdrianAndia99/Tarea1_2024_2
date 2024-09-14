using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rayDistance = 10f;
    private Vector2 moveInput;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPoint;

    private void Start()
    {
        myRBD2 = GetComponent<Rigidbody2D>();

    }
    private void Update()
    {
        myRBD2.velocity = moveInput * moveSpeed;

        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);

        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            ShootBullet();
        }
    }

    private void CheckFlip(float x_Position)
    {
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
    private void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseInput - (Vector2)bulletSpawnPoint.position).normalized;
        bulletRb.velocity = direction * 10f;

    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log("muevete pe");
    }
}