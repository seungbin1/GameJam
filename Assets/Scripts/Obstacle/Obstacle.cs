using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Vector3 position;

    protected virtual void Damage(Collider2D collider2D, bool canAttack)
    {
        if(collider2D.tag == "Player" && canAttack)
        {
            //collider2D.Player.hp--;   
            canAttack = false;
        }
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    protected virtual void Spawn()
    {
        transform.position = position;
    }

    protected virtual void Move(float Speed)
    {
        if(GameManager.instance.gameState == GameManager.GameState.Playing)
        {
            transform.position -= new Vector3(Speed * Time.deltaTime, 0, 0);
        }
    }

    protected virtual void Return()
    {
        if(transform.position.x < -10)
        {
            ObjectPool.instacne.ReturnGameObject(this.gameObject);
        }
    }
}
