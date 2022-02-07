using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : Obstacle
{
    [SerializeField]
    private Vector3 spawnPositon;

    private bool canAttack;

    [SerializeField]
    private float speed;

    private void OnEnable()
    {
        canAttack = true;
        Spawn(spawnPositon);
    }

    private void Update()
    {
        Move(speed);
    }

    protected override void Damage(Collider2D collider2D, bool canAttack)
    {
        base.Damage(collider2D, canAttack);
    }

    protected override void Spawn(Vector3 position)
    {
        base.Spawn(position);
    }

    protected override void Move(float Speed)
    {
        base.Move(Speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision, canAttack);
    }   
}
