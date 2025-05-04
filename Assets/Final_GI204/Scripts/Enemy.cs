using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    private Player player;
    private float distanceToPlayer;
    private float attackCooldown;
    private bool isAttack;
    private bool isAttackCooldown;

    private void Start()
    {
        Initialize();
        maxHealth = 1;
        health = maxHealth;
        player = FindAnyObjectByType<Player>();
        attackCooldown = 5f;
    }

    private void Update()
    {
        if (!isDeath)
        {
            CheckGround();
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (!isDeath)
        {
            Movement();
        }
    }

    // Movement logic
    public override void Movement()
    {
        if (!isAttack)
        {
            // F = MA :Start
            float mass = rb.mass;
            float acc = 200f;
            speed = mass * acc;
            distanceToPlayer = player.transform.position.x - transform.position.x;
            float moveDir = Mathf.Sign(distanceToPlayer);

            rb.linearVelocity = new Vector2(moveDir * speed * Time.deltaTime, rb.linearVelocity.y);
            // :End

            // Flip sprite :Start
            if (!Mathf.Approximately(moveDir, 0))
                transform.rotation = moveDir > 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            // :End

            anim.SetFloat("speed", Mathf.Abs(moveDir));
        }
    }

    // On attack
    public override void Attack()
    {
        if (Mathf.Abs(distanceToPlayer) <= 2.5f && !isAttackCooldown)
        {
            Debug.Log("Attack");
            isAttack = true;
            anim.SetTrigger("isAttack");

            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForSeconds(stateInfo.length);
        isAttack = false;

        isAttackCooldown = true;
        yield return new WaitForSeconds(attackCooldown);
        Debug.Log("Atk finish cooldown");
        isAttackCooldown = false;
    }
}
