using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class Player : Character
{
    public Projectile Bullet;
    public Rigidbody2D bombPrefab;
    public Transform firePoint;
    public GameObject target;

    public AudioClip jumpSound;

    private void Start()
    {
        Initialize();
        maxHealth = 3;
        health = maxHealth;
        jumpForce = 8f;
        target.SetActive(false);
    }

    private void Update()
   {
        if (!isDeath)
        {
            CheckGround();
            // Fire bullet
            Attack();
            ThrowBomb();
        }

        if (transform.position.y <= -30)
        {
            Death();
        }
   }

    private void FixedUpdate()
    {
        if (!isDeath)
        {
            Movement();
            Jump();
        }
    }

    // Throw bomb logic
    private void ThrowBomb()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            // Fire raycast on click point
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 10f);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            if (hit.collider != null)
            {
                target.transform.position = new Vector2(hit.point.x, hit.point.y);
                target.SetActive(true);
                Vector2 projectileVelocity = CalculateProjectile(firePoint.position, hit.point, 1);
                Rigidbody2D firedBomb = Instantiate(bombPrefab, firePoint.position, Quaternion.identity);
                firedBomb.linearVelocity = projectileVelocity;
                StartCoroutine(TargetRoutine());
            }
        }
    }

    IEnumerator TargetRoutine()
    {
        yield return new WaitForSeconds(1.25f);
        target.SetActive(true);
    }

    // Calculate projectile velocity
    private Vector2 CalculateProjectile(Vector2 origin, Vector2 target, float time)
    {
        // Projectile Motion Formula
        Vector2 distance = target - origin;

        // Vx = x / t
        float velocityX = distance.x / time;

        // Vy0 = y/t + 1/2 * g * t
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(velocityX, velocityY);
    }

    // Jump logic
    public void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGround)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
    }

    // Movement logic
    public override void Movement()
    {
        // F = MA :Start
        float mass = rb.mass;
        float acc = 325f;
        speed = mass * acc;
        float movement = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(movement * speed * Time.deltaTime, rb.linearVelocity.y);
        // :End

        // Flip sprite :Start
        if (!Mathf.Approximately(movement, 0))
            transform.rotation = movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        // :End

        anim.SetFloat("speed", Mathf.Abs(movement));
    }

    // Fire bullet logic
    public override void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, firePoint.position, transform.rotation);
        }
    }
}