using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : Obstacle, IDamage
{
    [SerializeField] private LayerMask layer;
    [SerializeField] private int attackPower;
    [SerializeField] private float speedX;   
    [SerializeField] private float speedY;
    [SerializeField] private float minY, maxY;

    void OnEnable()
    {
        speedX += GameManager.Instance.SpeedUP;
        Spawn();
        speedY = RandomSpeed(speedY - 1, speedY);
        minY = RandomSpeed(minY, minY + 0.5f);
        maxY = RandomSpeed(maxY-0.5f, maxY);
    }

    protected override void Update()
    {
        Move(speedX);
        Return();
    }

    public void OnDamage()
    {
        PlayerStatsManager.Instance.TakeDamage();
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
            collision.transform.GetChild(0).GetComponent<Player_Die>().Die();
        }
    }
}
