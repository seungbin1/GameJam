using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Obstacle
{
    [SerializeField]
    private Vector3 spawnPositon;

    private bool canAttack;

    private void OnEnable()
    {
        canAttack = true;
        Spawn(spawnPositon);
    }

    protected override void Damage(Collider2D collider2D, bool canAttack)
    {
        base.Damage(collider2D, canAttack);
    }

    protected override void Spawn(Vector3 position)
    {
        base.Spawn(position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision, canAttack);
    }
}
