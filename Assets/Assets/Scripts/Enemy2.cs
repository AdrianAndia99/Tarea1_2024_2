using UnityEngine;
public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform player;
    public Transform initialPosition;
    public GameObject projectilePrefab;
    public float projectileForce = 10f;
    public Transform shootPoint;
    public GameObject positionPlayer;

    private bool playerInRange = false;
    private Rigidbody2D rb;
    private Vector2 initialPos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPos = initialPosition.position;
    }
    void Update()
    {
        if (playerInRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);

            ShootProjectile();
        }
        else
        {
            if ((Vector2)transform.position != initialPos)
            {
                Vector2 direction = (initialPos - (Vector2)transform.position).normalized;
                rb.MovePosition(rb.position + direction * moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.transform;
            playerInRange = true;
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;

            positionPlayer = null;
        }
    }
    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        Rigidbody2D projectileRB = projectile.GetComponent<Rigidbody2D>();
        Vector2 direction = (player.position - shootPoint.position).normalized;
        projectileRB.velocity = direction * projectileForce;
        
    }
}