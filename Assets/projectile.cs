 using UnityEngine;

public class projectile : MonoBehaviour
{
    public float speed = 4;
    public Vector3 launchOffset;
    public bool thrown;
    
    private void Start()
    {
        if (thrown)
        {
            var direction = -transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
        transform.Translate(launchOffset);
        Destroy(gameObject, 5); //  Destroy after 5 seconds
    }

    public void Update()
    {
        if (!thrown)
        {
            transform.position += -transform.right * speed * Time.deltaTime;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       var enemy = collision.collider.GetComponent<EnemyHeath>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
        Destroy(gameObject);
    }


}
