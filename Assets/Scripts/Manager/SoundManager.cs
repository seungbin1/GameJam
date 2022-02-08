using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    private AudioSource button, game, jump;

    enum Audio
    {
        button, 
        game, 
        jump
    }

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        button = transform.Find("Button").GetComponent<AudioSource>();
        game = transform.Find("Game").GetComponent<AudioSource>();
        jump = transform.Find("Jump").GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        if(instance == this)
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


}
