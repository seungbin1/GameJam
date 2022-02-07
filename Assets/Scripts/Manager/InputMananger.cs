using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMananger : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Jump") && EventManager.TriggerEvent_Function("ISGROUND"))
        {
            EventManager.TriggerEvent_Action("JUMP");
        }  
    }
}
