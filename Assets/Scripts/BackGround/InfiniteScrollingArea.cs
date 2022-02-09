using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingArea : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private float denominator = 10f;

    private Vector3 startPos;
    private Vector3 firstArea;

    void Start()
    {
        startPos = transform.position;
        firstArea = transform.GetChild(0).TransformPoint(transform.GetChild(0).position);
    }

    void Update()
    {
        speed += Time.deltaTime / denominator;
        SpawnArea();
        Debug.Log(string.Format("Scroll Speed : {0}", speed));
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
