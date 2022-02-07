using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }


    public enum GameState
    {
        Playing,
        Stop
    }

    public GameState gameState;

    private void Start()
    {
        gameState = GameState.Playing;
    }
}
