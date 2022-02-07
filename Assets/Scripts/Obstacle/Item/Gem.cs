using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Obstacle
{
    [SerializeField]
    private float speedX;

    [SerializeField]
    private float speedY;

    [SerializeField]
    private float minY, maxY;

    private void OnEnable()
    {
        Spawn();
        Return();
    }

    private void Update()
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

    protected override void Spawn()
    {
        base.Spawn();
    }

    protected virtual void Return(Collider2D collision = null)
    {
        base.Return();
        if (collision)
        {
            ObjectPool.instacne.ReturnGameObject(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Return(collision);
            GameManager.instance.GetScore(1000);
        }
    }
}
