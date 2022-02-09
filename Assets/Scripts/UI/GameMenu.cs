using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System;

public class GameMenu : MonoBehaviour
{
    public enum Kind
    {
        GAMESTART,
        GAMESTOP,
        RESUME,
        RESTART,
        SETTING,
        EXIT,
        GAMEOVER,
        SETTINGEXIT,
        GAMEEXIT,
        BESTSCORE
    }
    public Kind kind;

    private Text bestScore;

    public GameObject stopButton;
    public GameObject menuObj=null;
    public GameObject settingObj;
    public GameObject gameOver;

    public string sceneName;

    private Button button;

    private AudioSource audioSource;

    private void OnEnable()
    {
        if(kind == Kind.BESTSCORE)
        {
            bestScore = GetComponent<Text>();
            BestScore();
        }
    }

    private void Start()
    {
        audioSource = GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>();
        button = GetComponent<Button>();

        switch (kind)
        {
            case Kind.GAMESTOP:
                button.onClick.AddListener(GameStopButton);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.RESUME:
                button.onClick.AddListener(Resume);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.RESTART:
                button.onClick.AddListener(Restart);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.SETTING:
                button.onClick.AddListener(Setting);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.EXIT:
                button.onClick.AddListener(Exit);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.SETTINGEXIT:
                button.onClick.AddListener(SettingExit);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.GAMEEXIT:
                button.onClick.AddListener(GameExit);
                button.onClick.AddListener(GameButtonSound);
                break;
            case Kind.GAMESTART:
                button.onClick.AddListener(GameStart);
                button.onClick.AddListener(GameButtonSound);
                break;
        }
    }

    private void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.GameOver && kind==Kind.GAMEOVER)
        {
            GameOver();
        }
    }



    //게임 씬에서 게임 멈춤 버튼
    private void GameStopButton()
    {
        Time.timeScale = 0;
        menuObj.SetActive(true);
        stopButton.SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.Stop;

        SoundManager.Instance.PauseGame();
    }

    //게임 멈춤에서 계속하기 버튼
    private void Resume()
    {
        Time.timeScale = 1;
        menuObj.SetActive(false);
        stopButton.SetActive(true);

        SoundManager.Instance.OnGame();
    }
    //메인 씬에서 게임 씬으로 이동
    private void GameStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        GameManager.Instance.gameState = GameManager.GameState.Playing;
    }

    //게임 다시시작
    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        GameManager.Instance.gameState = GameManager.GameState.Playing;
    }

    //게임 세팅
    private void Setting()
    {
        settingObj.SetActive(true);
    }

    //메인 화면으로 나가기
    private void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.gameState = GameManager.GameState.Main;
    }

    //세팅 나가기 및 볼륨 저장
    private void SettingExit()
    {
        GameManager.Instance.SaveData();
        settingObj.SetActive(false);
    }

    //게임 나가기
    private void GameExit()
    {
        Application.Quit();
    }

    //버튼 사운다
    private void GameButtonSound()
    {
        audioSource.Play();
    }

    private void GameOver()
    {
        gameOver.SetActive(true);
        stopButton.SetActive(false);
    }

    private void BestScore()
    {
        bestScore.text = "BestScore\n"+GameManager.Instance.data.bestscore;
    }
}
