using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMananger : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            EventManager.TriggerEvent_Action("JUMP");
        }  
    }
}
