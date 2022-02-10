using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingArea : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxSpeed = 5f;

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
        Debug.Log(string.Format("Scroll Speed : {0}", speed));
    }

    void SpawnArea()
    {
        speed = Mathf.Clamp(speed + GameManager.Instance.SpeedUP, speed + GameManager.Instance.SpeedUP, maxSpeed);

        transform.position -= Vector3.right * Time.deltaTime * speed;

        if (transform.GetChild(1).TransformPoint(transform.GetChild(1).position).x <= firstArea.x)
        {
            transform.position = startPos;
        }
    }
}
