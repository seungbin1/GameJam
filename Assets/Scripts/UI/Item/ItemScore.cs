using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ItemScore : MonoBehaviour
{
    private Text cherryText;
    private Text gemText;

    void Start()
    {
        cherryText = transform.GetChild(0).GetComponent<Text>();
        gemText = transform.GetChild(1).GetComponent<Text>();

        OnScoreText(false);

        EventManager.AddEvent_Action_Int("GETITEMSCORE", GetItemScore); 
        EventManager.AddEvent_Action_Bool("ONSCORETEXT", OnScoreText);
        EventManager.AddEvent_Action_GameObject("SETITEMSCOREPOSITION", SetItemScorePosition);
    }

    void OnScoreText(bool isOn) // 텍스트 On/Off
    {
        if (cherryText.gameObject.activeSelf == false)
        {
            cherryText.gameObject.SetActive(isOn);
        }
        else
        {
            gemText.gameObject.SetActive(isOn);
        }
    }

    void GetItemScore(int score) // 텍스트에 점수 적용
    {
        if (cherryText.gameObject.activeSelf == false)
        {
            cherryText.text = score.ToString();
        }
        else
        {
            gemText.text = score.ToString();
        }
    }

    void ItemScoreColor(GameObject item)
    {
        switch (item.tag)
        {
            case "Cherry":
                cherryText.color = Color.yellow;
                break;
            case "Gem":
                gemText.color = Color.blue;
                break;
        }
    }

    void SetItemScorePosition(GameObject item) // 텍스트 위치 
    {
        OnScoreText(true);
        if (cherryText.gameObject.activeSelf == false)
        {
            cherryText.transform.position = Camera.main.WorldToScreenPoint(item.transform.position);
        }
        else
        {
            gemText.transform.position = Camera.main.WorldToScreenPoint(item.transform.position);
        }
        ItemScoreColor(item);
        StartCoroutine(HideItemScore());
    }

    IEnumerator HideItemScore()
    {
        yield return new WaitForSeconds(1f);
        OnScoreText(false);
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent("GETITEMSCORE");
        EventManager.RemoveEvent("SETITEMSCOREPOSITION");
    }
}
