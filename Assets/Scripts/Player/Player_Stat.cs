using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Stat : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    public int HP { get => hp;}

    [SerializeField] private float speed = 10f;
    public float Speed { get => speed; }

    [SerializeField] private float jumpPower = 20f;
    public float JumpPower { get => jumpPower; }
}
