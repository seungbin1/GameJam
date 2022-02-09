using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusPool : MonoBehaviour
{
    [SerializeField]
    private GameObject[] prefab;

    [SerializeField]
    private float maxSpawnLate = 6;
    [SerializeField]
    private float minSpawnLate = 2;

    private float spawnlate;

    private void Start()
    {
        spawnlate = Random.Range(minSpawnLate, maxSpawnLate);
    }

    private void Update()
    {
        if (GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            spawnlate -= Time.deltaTime;
            if (spawnlate <= 0)
            {
                spawnlate = Random.Range(minSpawnLate, maxSpawnLate); ;
                ObjectPool.instacne.GetObject(prefab[Random.Range(0, prefab.Length)]);
            }
        }
    }
}
