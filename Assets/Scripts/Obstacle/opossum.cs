using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Obstacle
{
    private bool canAttack;

    [SerializeField]
    private float speed;

    private void OnEnable()
    {
        canAttack = true;
        Spawn();
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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision, canAttack);
        canAttack = false;
    }
}
