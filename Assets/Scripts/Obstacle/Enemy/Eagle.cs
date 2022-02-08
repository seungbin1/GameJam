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
        Spawn();
    }

    protected override void Update()
    {
        Move(speedX);
        Return();
    }

    public void OnDamage(int damage)
    {
        PlayerStatsManager.Instance.TakeDamage(damage);
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

   
}
