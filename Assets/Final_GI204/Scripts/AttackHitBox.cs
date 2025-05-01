using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    // If hit box trigger with player tag 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().TakeDamage(1);
        }
    }
}
