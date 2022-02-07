using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;

public class GameMenu : MonoBehaviour
{
    public enum Kind
    {
        GAMESTOP,
        RESUME,
        RESTART,
        SETTING,
        EXIT,
        GAMEOVER,
        SETTINGEXIT,
        GAMESETTINGEXIT
    }
    public Kind kind;

    public GameObject stopButton;
    public GameObject menuObj=null;
    public GameObject settingObj;
    public GameObject gameOver;

    public string sceneName;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
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
        }
    }
    //���� ������ ���� ���� ��ư
    public void GameStopButton()
    {
        Time.timeScale = 0;
        menuObj.SetActive(true);
        gameObject.SetActive(false);
    }

    //���� ���㿡�� ����ϱ� ��ư
    public void Resume()
    {
        Time.timeScale = 1;
        menuObj.SetActive(false);
        stopButton.SetActive(true);
    }

    //���� �ٽý���
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    //���� ����
    public void Setting()
    {
        settingObj.SetActive(true);
    }

    //���� ȭ������ ������
    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    //���� ������ �� ���� ����
    public void SettingExit()
    {
        settingObj.SetActive(false);
    }
}
