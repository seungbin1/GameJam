using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Obstacle, IHeal
{
    [SerializeField] private int healAmount = 1;
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float minY, maxY;

    void OnEnable()
    {
        Spawn();
        Return();
    }

    protected override void Update()
    {
        Move(speedX);
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

    protected virtual void Return(Collider2D collision = null)
    {
        base.Return();
        if (collision)
        {
            ObjectPool.instacne.ReturnGameObject(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Return(collision);
            OnHeal(healAmount);
        }
    }

    public void OnHeal(int heal)
    {
        PlayerStatsManager.Instance.TakeHeal(heal);
    }
}