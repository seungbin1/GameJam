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
        Run();
    }

    void Run()
    {
        rigid.velocity = new Vector2(Vector2.right.x * PlayerStatsManager.Instance.Speed, rigid.velocity.y);
    }

    void Jump()
    {
        if (IsGround())
        {
            rigid.AddForce(Vector2.up * PlayerStatsManager.Instance.JumpPower, ForceMode2D.Impulse);
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
