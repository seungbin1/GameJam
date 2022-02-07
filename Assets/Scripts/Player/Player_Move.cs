using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : Player
{
    protected override void Start()
    {
        base.Start();
        EventManager.AddEvent("JUMP", Jump);
    }

    protected override void Update()
    {
        base.Update();
        Run();
    }

    void Run()
    {
        rigid.velocity = new Vector2(Vector2.right.x * stat.Speed, rigid.velocity.y);
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * stat.JumpPower, ForceMode2D.Impulse);
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent("JUMP");
    }
}
