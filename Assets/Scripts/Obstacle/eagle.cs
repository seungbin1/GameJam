using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Obstacle
{
    private bool canAttack;

    [SerializeField]
    private float speedX;   

    [SerializeField]
    private float speedY;

    [SerializeField]
    private float minY, maxY;

    private void OnEnable()
    {
        canAttack = true;
        Spawn();
    }

    private void Update()
    {
        Move(speedX);
        Return();
    }

    protected override void Damage(Collider2D collider2D, bool canAttack)
    {
        base.Damage(collider2D, canAttack);
    }

    protected override void Move(float Speed)
    {
        base.Move(Speed);
        transform.position += new Vector3(0, speedY * Time.deltaTime, 0);

        if (transform.position.y < minY || transform.position.y > maxY)
        {
            speedY = -speedY;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damage(collision, canAttack);
        canAttack = false;
    }
}
