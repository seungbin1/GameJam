using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Obstacle
{
    [SerializeField] private float speedX;   
    [SerializeField] private float speedY;
    private float currentSpeed;
    [SerializeField] private float minY, maxY;

    void OnEnable()
    {
        currentSpeed = speedX + GameManager.Instance.SpeedUP;
        Spawn();
        speedX = RandomSpeed(speedX - 1, speedX);
        speedY = RandomSpeed(speedY - 1, speedY);
        minY = RandomSpeed(minY, minY +0.5f);
        maxY = RandomSpeed(maxY-0.5f, maxY);
    }

    void Update()
    {
        Move(currentSpeed);
        Return();
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnDamage();
            collision.transform.GetComponent<Player_Die>().Die();
        }
    }
}
