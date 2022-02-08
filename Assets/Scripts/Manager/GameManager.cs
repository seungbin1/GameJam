using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class GameManager : MonoBehaviour
{
    //�̱���
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    //����
    private int first = 0;
    public class Data
    {
        public double mainSound;
        public double gameSound;
        public double effectSound;
        public int bestscore;
        public Data(int score, double mainSound, double gameSound, double effectSound)
        {
            this.bestscore = score;
            this.mainSound = mainSound;
            this.gameSound = gameSound;
            this.effectSound = effectSound;
        }

        public void SaveScore(int score)
        {
            this.bestscore = score;
        }

        public void SaveSound(double mainSound, double gameSound, double effectSound)
        {
            this.mainSound = mainSound;
            this.gameSound = gameSound;
            this.effectSound = effectSound;
        }
    }

    public Data data;

    //����
    [HideInInspector]
    private int score;
    [HideInInspector]
    public int bestScore;

    //�Ҹ�
    [HideInInspector]
    public float mainSound;
    [HideInInspector]
    public float gameSound;
    [HideInInspector]
    public float effectSound;
    public enum GameState
    {
        Playing,
        Stop,
        GameOver
    }

    public GameState gameState;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        //���� �Ҹ�����, �ְ� ����, �ҷ�����

        first = PlayerPrefs.GetInt("First");
        if (first == 0)
        {
            data = new Data(0, 0.5f, 0.5f, 0.5f);
            Save(data);
            first++;
            PlayerPrefs.SetInt("First", first);
        }

        JsonData json = Load();
        bestScore = int.Parse(json["bestscore"].ToString());
        mainSound = float.Parse(json["mainSound"].ToString());
        gameSound = float.Parse(json["gameSound"].ToString());
        effectSound = float.Parse(json["effectSound"].ToString());
        data = new Data(bestScore, mainSound, gameSound, effectSound);

    }

    public void GetScore(int score)
    {
        this.score = this.score + score;
        BestScore(this.score);
    }

    public int SetScore()
    {
        return score;
    }

    //����
    public void Save(Data data)
    {
        JsonData jsondata = JsonMapper.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + @"\data.json", jsondata.ToString());
    }

    JsonData Load()
    {
        string jsonString = System.IO.File.ReadAllText(Application.persistentDataPath + @"\data.json");
        JsonData jsondata = JsonMapper.ToObject(jsonString);
        return jsondata;
    }

    //�ְ� ����
    public void BestScore(int score)
    {
        JsonData json = Load();
        if (score > bestScore)
        {
            bestScore = score;
            data.SaveScore(bestScore);
            Save(data);
        }
    }
}