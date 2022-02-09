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
        GAMEEXIT
    }
    public Kind kind;

    public GameObject stopButton;
    public GameObject menuObj=null;
    public GameObject settingObj;
    public GameObject gameOver;

    public string sceneName;

    private Button button;

    private AudioSource audioSource;
    private void Start()
    {
        //audioSource = GameObject.Find("SoundManager").transform.GetChild(0).GetComponent<AudioSource>();

        button = GetComponent<Button>();

        button.onClick.AddListener(GameButtonSound);
        switch (kind)
        {
            case Kind.GAMESTOP:
                button.onClick.AddListener(GameStopButton);
                break;
            case Kind.RESUME:
                button.onClick.AddListener(Resume);
                break;
            case Kind.RESTART:
                button.onClick.AddListener(Restart);
                break;
            case Kind.SETTING:
                button.onClick.AddListener(Setting);
                break;
            case Kind.EXIT:
                button.onClick.AddListener(Exit);
                break;
            case Kind.SETTINGEXIT:
                button.onClick.AddListener(SettingExit);
                break;
            case Kind.GAMEEXIT:
                button.onClick.AddListener(GameExit);
                break;
            case Kind.GAMESTART:
                button.onClick.AddListener(GameStart);
                break;
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
        //audioSource.Play();
    }
}
