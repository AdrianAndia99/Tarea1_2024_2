using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 3; 

    private Vector3 targetPosition;

    public void SetTarget(Vector3 target)
    {
        targetPosition = target;
    }

    void Update()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;

        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }
}
