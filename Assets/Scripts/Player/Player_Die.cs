using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : Player
{
    void Die()
    {
        if (stat.HP <= 0)
        {
            animator.SetBool("Die", true);
        }  
    }
}
