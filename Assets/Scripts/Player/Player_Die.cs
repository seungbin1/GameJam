using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Die : Player
{
    public void Die()
    {
        animator.SetBool("Die", true);
        Destroy(gameObject);
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).transform.localPosition += new Vector3(1.25f,0,0);
        }
    }

    protected override void Start()
    {
        base.Start();
    }
}
