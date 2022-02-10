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

        OnChrryText(false);
        OnGemText(false);

        EventManager.AddEvent_Action_Int("GETITEMSCORE", GetItemScore); 
        EventManager.AddEvent_Action_GameObject("SETITEMSCOREPOSITION", SetItemScorePosition);
    }

    void OnChrryText(bool isOn) // 텍스트 On/Off
    {
        cherryText.gameObject.SetActive(isOn);
    }

    void OnGemText(bool isOn) // 텍스트 On/Off
    {
        gemText.gameObject.SetActive(isOn);
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
                if (cherryText.gameObject.activeSelf == true)
                {
                    cherryText.color = Color.yellow;
                }
                else
                {
                    gemText.color = Color.yellow;
                }
                break;
            case "Gem":
                if (cherryText.gameObject.activeSelf == true)
                {
                    cherryText.color = Color.blue;
                }
                else
                {
                    gemText.color = Color.blue;
                }
                break;
        }
    }

    void SetItemScorePosition(GameObject item) // 텍스트 위치 
    {
        if (cherryText.gameObject.activeSelf == false)
        {
            OnChrryText(true);
            cherryText.transform.position = Camera.main.WorldToScreenPoint(item.transform.position);
            StartCoroutine(HideCherryScore());
        }
        else
        {
            OnGemText(true);
            gemText.transform.position = Camera.main.WorldToScreenPoint(item.transform.position);
            StartCoroutine(HideGemScore());
        }
        ItemScoreColor(item);
    }

    IEnumerator HideCherryScore()
    {
        yield return new WaitForSeconds(1f);
        OnChrryText(false);
    }   
    
    IEnumerator HideGemScore()
    {
        yield return new WaitForSeconds(1f);
        OnChrryText(false);
    }

    void OnDestroy()
    {
        EventManager.RemoveEvent("GETITEMSCORE");
        EventManager.RemoveEvent("SETITEMSCOREPOSITION");
    }
}
