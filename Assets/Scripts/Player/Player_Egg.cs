using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Egg : MonoBehaviour
{
    private void OnEnable()
    {
        switch (transform.parent.childCount)
        {
            case 1:
                transform.localPosition = new Vector3(0, 0.55f, 0); ;
                break; 
            case 2:
                transform.localPosition = new Vector3(-1.25f,0.55f,0);
                break;            
            case 3:
                transform.localPosition = new Vector3(-2.5f,0.55f,0);
                break;
        }
    }
}
