using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    private float maxtime;
    private float time;

    private Text text;

    private void Start()
    {
        time = maxtime;
        text = GetComponent<Text>();
    }
    private void Update()
    {
        TextSeting();

        time -= Time.deltaTime;
        if(time < 0)
        {
            time = maxtime;
            GameManager.instance.GetScore(10);
        }
    }

    private void TextSeting()
    {
        text.text = "SCORE\n" + GameManager.instance.SetScore();
    }
}
