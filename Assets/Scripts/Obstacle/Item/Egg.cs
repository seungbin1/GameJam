using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : Obstacle
{
    [SerializeField] private int healAmount = 1;
    [SerializeField] private float speedX;

    [SerializeField] private int type;

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
            collision.GetComponent<Player_GetEgg>().GetEgg(GetEggType());
        }
    }

    public void OnHeal(int heal)
    {
        PlayerStatsManager.Instance.TakeHeal(heal);
    }

    public int GetEggType()
    {
        return type;
    }
}
