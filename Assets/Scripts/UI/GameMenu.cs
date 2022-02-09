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



    //���� ������ ���� ���� ��ư
    private void GameStopButton()
    {
        Time.timeScale = 0;
        menuObj.SetActive(true);
        stopButton.SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.Stop;

        SoundManager.Instance.PauseGame();
    }

    //���� ���㿡�� ����ϱ� ��ư
    private void Resume()
    {
        Time.timeScale = 1;
        menuObj.SetActive(false);
        stopButton.SetActive(true);

        SoundManager.Instance.OnGame();
    }
    //���� ������ ���� ������ �̵�
    private void GameStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        GameManager.Instance.gameState = GameManager.GameState.Playing;
    }

    //���� �ٽý���
    private void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        GameManager.Instance.gameState = GameManager.GameState.Playing;
    }

    //���� ����
    private void Setting()
    {
        settingObj.SetActive(true);
    }

    //���� ȭ������ ������
    private void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
        GameManager.Instance.gameState = GameManager.GameState.Main;
    }

    //���� ������ �� ���� ����
    private void SettingExit()
    {
        GameManager.Instance.SaveData();
        settingObj.SetActive(false);
    }

    //���� ������
    private void GameExit()
    {
        Application.Quit();
    }

    //��ư ����
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
