using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private float speed = 2;

    private Vector3 startPos;
    private Vector3 firstArea;

    void Start()
    {
        startPos = transform.position;
        firstArea = transform.GetChild(0).TransformPoint(transform.GetChild(0).position);
    }

    void Update()
    {
        SpawnArea();
    }

    void SpawnArea()
    {
        transform.position -= Vector3.right * Time.deltaTime * speed;

        if (transform.GetChild(1).TransformPoint(transform.GetChild(1).position).x <= firstArea.x)
        {
            transform.position = startPos;
        }
    }
}
