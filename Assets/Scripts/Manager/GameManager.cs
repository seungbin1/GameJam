using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public enum GameState
    {
        Playing,
        Stop
    }

    public GameState gameState;

    [HideInInspector]
    public float score;


    private void Awake()
    {
        instance = this;
    }

    public void GetScore(float score)
    {
        this.score = this.score + score;
    }
}
