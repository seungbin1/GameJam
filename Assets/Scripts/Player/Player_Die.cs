using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : Player
{
    void Die()
    {
        animator.SetBool("Die", true);
        GameManager.Instance.gameState = GameManager.GameState.Stop;
    }
}
