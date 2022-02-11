using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Obstacle
{
    [SerializeField] private float speedX;   
    [SerializeField] private float speedY;
    private float currentSpeedX, currentSpeedY;
    [SerializeField] private float minY, maxY;
    private float min, max;

    void OnEnable()
    {
        currentSpeedX = speedX + GameManager.Instance.SpeedUP;
        Spawn();
        currentSpeedX = RandomSpeed(currentSpeedX - 1, currentSpeedX);
        currentSpeedY = RandomSpeed(speedY - 1, speedY);
        min = RandomSpeed(minY, minY +0.5f);
        max = RandomSpeed(maxY-0.5f, maxY);
    }

    void Update()
    {
        Move(currentSpeedX);
        Return();
    }


    protected override void Move(float Speed)
    {
        base.Move(Speed);
        transform.position += new Vector3(0, currentSpeedY * Time.deltaTime, 0);

        if (transform.position.y < min || transform.position.y > max)
        {
            currentSpeedY = -currentSpeedY;
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
