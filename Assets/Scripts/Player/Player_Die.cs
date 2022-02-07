using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : Player
{
    void Die()
    {
        animator.SetBool("Die", true);
        GameManager.instance.gameState = GameManager.GameState.Stop;
    }
}
