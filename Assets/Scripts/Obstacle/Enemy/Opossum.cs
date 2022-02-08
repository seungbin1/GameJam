using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Obstacle, IDamage
{
    [SerializeField] private int attackPower;
    [SerializeField] private float speed;

    void OnEnable()
    {
        Spawn();
    }

    protected override void Update()
    {
        Move(speed);
        Return();
    }

    public void OnDamage(int damage)
    {
        PlayerStatsManager.Instance.TakeDamage(damage);
    }

    protected override void Move(float Speed)
    {
        base.Move(Speed);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDamage(attackPower);
        }
    }
}
