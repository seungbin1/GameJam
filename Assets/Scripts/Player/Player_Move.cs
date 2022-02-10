using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player_Move : Player
{
    [SerializeField] private LayerMask layer;
    private int jumpcount=2;

    protected override void Start()
    {
        base.Start();
        EventManager.AddEvent_Action("JUMP", Jump);
    }

    protected override void Update()
    {
        base.Update();
        if (IsGround())
        {
            jumpcount = 1;
        }
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.5f, 4.5f), -1.65f);

    }

    void Jump()
    {
        if (jumpcount !=0)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector2.up * PlayerStatsManager.Instance.JumpPower, ForceMode2D.Impulse);
            SoundManager.Instance.GetJump().Play();
            jumpcount--;
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
