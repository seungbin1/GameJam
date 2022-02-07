using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected virtual void Damage(int damage, Collider2D collider2D, bool canAttack)
    {
        if(collider2D.tag == "Player" && canAttack)
        {
            //collider2D.Player.hp -= damage;   
            canAttack = false;
        }
    }

    protected virtual void Spawn(Vector3 position)
    {
        transform.position = position;
    }
}
