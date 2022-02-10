using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cherry : Obstacle, IScore
{ 
    [SerializeField] private int scorePoint = 100;
    [SerializeField] private float speedX;
    [SerializeField] private float speedY;
    [SerializeField] private float minY, maxY;

    void OnEnable()
    {
        Spawn();
        speedY = RandomSpeed(speedY-1, speedY);
    }

    void Update()
    {
        Move(speedX);
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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SoundManager.Instance.OnCoin();
            Return(collision);
            OnGetScore(scorePoint);
            EventManager.TriggerEvent_Action("SETITEMSCOREPOSITION", gameObject); // 아이템 스코어 텍스트 위치 선정
        }
    }

    public void OnGetScore(int score)
    {
        GameManager.Instance.GetScore(score);
        EventManager.TriggerEvent_Action("GETITEMSCORE", score);
    }
}