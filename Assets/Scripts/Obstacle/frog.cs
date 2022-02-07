using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Obstacle
{

    private bool canAttack;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float superJump;
    [SerializeField]
    private float maxJumpTime;
    private float jumpTime;

    Rigidbody2D rigid;
    Animator animator;

    private void OnEnable()
    {
        jumpTime = maxJumpTime;
        canAttack = true;
        Spawn();
    }

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move(speed);
        Return();
    }

    protected override void Damage(Collider2D collider2D, bool canAttack)
    {
        base.Damage(collider2D, canAttack);
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
        Damage(collision, canAttack);
        canAttack = false;
    }   
}
