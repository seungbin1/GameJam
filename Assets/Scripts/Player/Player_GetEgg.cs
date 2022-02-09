using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_GetEgg : MonoBehaviour
{ 
    [SerializeField] private GameObject[] eggs;

    public void GetEgg(int type)
    {
        if (transform.childCount < 3)
        {
            Instantiate(eggs[type], this.transform);
        }
    }
}
