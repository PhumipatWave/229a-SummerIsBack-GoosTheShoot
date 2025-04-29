using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 1;
    public float jumpForce = 1;
    private Rigidbody2D Rigidbody;

    public ProjectileBullet ProjectilePrefeb;
    public BombProjectile LaunchableProjectilePrefeb;
    public Transform launchOffset;

    private void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();    
    }

    
   private void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpeed;

        if (!Mathf.Approximately(movement, 0))
            transform.rotation =movement > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;

        if (Input.GetButtonDown("Jump") && Mathf.Abs(Rigidbody.linearVelocity.y) < 0.001f)
        {
            Rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(ProjectilePrefeb, launchOffset.position, transform.rotation);
        }
        if (Input.GetButtonDown("Fire2"))
        {
            Instantiate(LaunchableProjectilePrefeb, launchOffset.position, transform.rotation);
        }
    }
}
