using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Obstacle, IDamage
{
    [SerializeField] private LayerMask player;
    [SerializeField] private LayerMask ground;

    [SerializeField] private int attackPower;
    [SerializeField] private float speed;
    [SerializeField] private float superJump;
    [SerializeField] private float maxJumpTime;

    private float jumpTime;

    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    private Animator animator;

    void OnEnable()
    {
        jumpTime = maxJumpTime;
        Spawn();
    }

    protected override void Start()
    {
        base.Start();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    protected override void Update()
    {
        Move(speed);
        Return();
    }

    public void OnDamage()
    {
        PlayerStatsManager.Instance.TakeDamage();
    }

    protected override void Move(float Speed)
    {
        base.Move(Speed);
        animator.SetBool("Jump", false);

        //jumpTime -= Time.deltaTime;


        //if (jumpTime < 0)
        //{
        //    Jump();
        //    jumpTime = maxJumpTime;
        //}
    }

    void Jump()
    {
        rigid.velocity = Vector2.up * superJump;
        animator.SetBool("Jump", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Jump();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDamage();
            collision.transform.GetChild(0).GetComponent<Player_Die>().Die();
        }
    }
}
