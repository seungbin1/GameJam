using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class GameManager : MonoBehaviour
{
    //싱글톤
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    //저장
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

    //점수
    [HideInInspector]
    private int score;
    [HideInInspector]
    public int bestScore;

    //소리
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

        //저장 소리세팅, 최고 점수, 불러오기

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

    //저장
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

    //최고 점수
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