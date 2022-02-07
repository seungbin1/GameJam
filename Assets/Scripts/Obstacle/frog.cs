using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Obstacle, IDamage
{
    [SerializeField] private int attackPower;
    [SerializeField] private float speed;
    [SerializeField] private float superJump;
    [SerializeField] private float maxJumpTime;

    private float jumpTime;
    private bool canAttack;

    Rigidbody2D rigid;
    Animator animator;

    void OnEnable()
    {
        jumpTime = maxJumpTime;
        canAttack = true;
        Spawn();
    }

    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        Move(speed);
        Return();
    }

    public void OnDamage(int damage)
    {
        PlayerStatsManager.Instance.TakeDamage(damage);
    }

    protected override void Move(float Speed)
    {
        base.Move(Speed);

        jumpTime -= Time.deltaTime;

        animator.SetBool("Jump", false);
        if (jumpTime < 0)
        {
            Jump();
            jumpTime = maxJumpTime;
        }
    }

    private void Jump()
    {
        rigid.velocity = Vector2.up * superJump;
        animator.SetBool("Jump", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDamage(attackPower);
        }  
    }
}
