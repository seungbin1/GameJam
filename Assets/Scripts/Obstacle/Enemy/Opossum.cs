using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Obstacle, IDamage
{
    [SerializeField] private float speed;

    void OnEnable()
    {
        speed += GameManager.Instance.SpeedUP;
        speed = RandomSpeed(speed - 1, speed);
        Spawn();
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
