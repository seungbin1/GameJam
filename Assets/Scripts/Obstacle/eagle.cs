using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Obstacle
{
    [SerializeField]
    private Vector3 spawnPositon;

    private void OnEnable()
    {
        Spawn(spawnPositon);
    }

    protected override void Damage(int damage, Collider2D collider2D, bool canAttack)
    {
        base.Damage(damage, collider2D, canAttack);
    }

    protected override void Spawn(Vector3 position)
    {
        base.Spawn(position);
    }
}
