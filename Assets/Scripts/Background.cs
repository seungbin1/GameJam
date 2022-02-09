using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private List<GameObject> areas = new List<GameObject>();
    [SerializeField] private float speed = 2;
    [SerializeField] private float minPosition =-9;
    [SerializeField] private float initPosition = 12;

    void Update()
    {
        SpawnArea();
    }

    void SpawnArea()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            if (transform.GetChild(i).transform.localPosition.x <= minPosition)
            {
                transform.GetChild(i).transform.localPosition = new Vector3(initPosition, 0, 0);
            }
        }
    }
}
