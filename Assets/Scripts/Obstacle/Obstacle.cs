using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private Vector3 position;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual float RandomSpeed(float min, float max)
    {
        return Random.Range(min, max);
    }


    protected virtual void Spawn()
    {
        transform.position = position;
    }

    protected virtual void Move(float speed)
    {
        if(GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
    }

    protected virtual void OnDamage()
    {
        PlayerStatsManager.Instance.TakeDamage();
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

    protected virtual void Return()
    {
        if(transform.position.x < -10)
        {
            ObjectPool.instacne.ReturnGameObject(this.gameObject);
        }
    }
}
