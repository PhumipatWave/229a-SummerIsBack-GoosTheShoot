using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject groundCheck;
    public LayerMask groundLayer;

    public int health;
    public int maxHealth;
    public float speed;
    public float jumpForce;
    public bool isGround;
    public bool isDeath;

    // Initialize
    protected void Initialize()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        isDeath = false;
    }

    public abstract void Movement();
    public abstract void Attack();

    // Check is character is on ground
    public void CheckGround()
    {
        if (Physics2D.Raycast(groundCheck.transform.position, -transform.up, 1.5f, groundLayer))
        {
            isGround = true;
            Debug.Log("Is Ground");

            if (this.CompareTag("Player"))
            {
                anim.SetBool("isGround", true);
            }
        }
        else
        {
            isGround = false;
            Debug.Log("Is Air");

            if (this.CompareTag("Player"))
            {
                anim.SetBool("isGround", false);
            }
        }
        Debug.DrawRay(groundCheck.transform.position, Vector2.down, Color.red);
    }

    // On take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        anim.SetTrigger("isDamaged");

        if (health <= 0) Death();
    }

    // On Death
    public void Death()
    {
        health = 0;
        anim.SetBool("isDeath", true);
        isDeath = true;
        Destroy(this.gameObject, 1.25f);
    }
}
