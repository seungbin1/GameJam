using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Obstacle, IDamage
{ 
    [SerializeField] private float speed;
    [SerializeField] private float superJump;
    [SerializeField] private float maxJumpTime;
    [SerializeField] private float minJumpTime;

    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    private Animator animator;

    void OnEnable()
    {
        speed += GameManager.Instance.SpeedUP;
        speed = RandomSpeed(speed - 0.5f, speed);
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            StopCoroutine(Jump());
            StartCoroutine(Jump());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDamage();
            collision.transform.GetComponent<Player_Die>().Die();
        }
    }

    IEnumerator Jump()
    {
        yield return new WaitForSeconds(RandomSpeed(minJumpTime, maxJumpTime));
        rigid.velocity = Vector2.up * superJump;
        animator.SetBool("Jump", true);
    }
}