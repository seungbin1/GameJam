using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Rigidbody2D rigid;
    protected BoxCollider2D collider;
    protected SpriteRenderer sprtie;
    protected Animator animator;

    protected virtual void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        sprtie = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {

    }
}
