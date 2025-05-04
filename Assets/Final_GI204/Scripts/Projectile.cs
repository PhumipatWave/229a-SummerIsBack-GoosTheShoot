using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip shootSound;
    public AudioClip explosionSound;

    public float speed = 4.5f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (this.CompareTag("Bullet"))
        {
            audioSource.PlayOneShot(shootSound);
        }

        Destroy(gameObject, 3f);
    }

    private void Update()
    {
        if (this.CompareTag("Bullet"))
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (this.CompareTag("Bomb"))
            {
                audioSource.PlayOneShot(explosionSound);
            }

            collision.GetComponent<Enemy>().TakeDamage(1);
            Destroy(gameObject);
        }
    }
}