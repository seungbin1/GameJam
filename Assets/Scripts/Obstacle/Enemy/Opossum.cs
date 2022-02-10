using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opossum : Obstacle
{
    [SerializeField] private float speed;
    private float currentSpeed;

    void OnEnable()
    {
        currentSpeed = speed + GameManager.Instance.SpeedUP;
        speed = RandomSpeed(speed - 1, speed);
        Spawn();
    }

    void Update()
    {
        Move(currentSpeed);
        Return();
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
            collision.transform.GetComponent<Player_Die>().Die();
        }
    }
}
