using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Move : Player
{
    [SerializeField] private LayerMask layer;

    protected override void Start()
    {
        base.Start();
        EventManager.AddEvent_Action("JUMP", Jump);
    }

    protected override void Update()
    {
        base.Update();
    }

    void Jump()
    {
        if (IsGround())
        {
            rigid.AddForce(Vector2.up * PlayerStatsManager.Instance.JumpPower, ForceMode2D.Impulse);
            SoundManager.Instance.GetJump().Play();
        }   
    }

    bool IsGround()
    {
        return Physics2D.OverlapBox(collider.bounds.center, collider.bounds.size, 180f, layer);
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent("JUMP");
    }
}
