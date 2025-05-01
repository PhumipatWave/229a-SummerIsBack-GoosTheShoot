using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 4.5f;

    private void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}