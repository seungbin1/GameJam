using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Player_Stat stat;
    protected Rigidbody2D rigid;
    protected BoxCollider2D collider;
    protected SpriteRenderer sprtie;
    protected Animator animator;

    void Awake()
    {
        stat = GetComponent<Player_Stat>();
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprtie = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }
}
