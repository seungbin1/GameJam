using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance { get { return instance; } }

    public AudioSource Game
    {
        get
        {
            if(game == null)
            {
                game = transform.Find("Game").GetComponent<AudioSource>();
            }

            return game;
        }
    }
    private AudioSource button, game, jump, main;

    private void Awake()
    {
        button = transform.Find("Button").GetComponent<AudioSource>();
        game = transform.Find("Game").GetComponent<AudioSource>();
        jump = transform.Find("Jump").GetComponent<AudioSource>();
        main = transform.Find("Main").GetComponent<AudioSource>();

        SceneManager.sceneLoaded += OnSceneLoaded;

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void OnDestroy()
    {
        if(Instance == this)
        {
            instance = null;
        }
    }


    public AudioSource GetButton()
    {
        return button;
    }    
    
    public AudioSource GetGame()
    {
        return game;
    }   
    
    public AudioSource GetJump()
    {
        return jump;
    }
    public AudioSource GetMain()
    {
        return main;
    }

    public void OnMain()
    {
        main.Play();
        Game.Stop();
    }

    public void OnGame()
    {
        print(game);
        Game.Play();
        main.Stop();
    }

    public void PauseGame()
    {
        game.Pause();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this == null) return;

        if (GameManager.Instance.gameState == GameManager.GameState.Main)
        {
            OnMain();
        }

        else if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            OnGame();
        }
    }
}
