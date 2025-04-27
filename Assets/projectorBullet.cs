using UnityEngine;

public class projectorBullet : MonoBehaviour
{
    public float speed = 4.5f;

    private void Update()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHeath>().TakeHit(1f);
        }
    }








}

