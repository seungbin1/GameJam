using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float maxSpawnLate=6;    
    [SerializeField]
    private float minSpawnLate=2;

    private float clampMin, clampMax;

    private float spawnlate;

    private void Start()
    {
        clampMin = minSpawnLate;
        clampMax = maxSpawnLate;
        RandomLate();
    }

    private void Update()
    {
        if(GameManager.Instance.gameState == GameManager.GameState.Playing)
        {
            spawnlate -= Time.deltaTime;
            if(spawnlate <= 0)
            {
                RandomLate();
                ObjectPool.instacne.GetObject(prefab);
            }
        }
    }

    private void RandomLate()
    {
        minSpawnLate = RandomSpawnLate(minSpawnLate - minSpawnLate/20, minSpawnLate);
        maxSpawnLate = RandomSpawnLate(maxSpawnLate - maxSpawnLate / 20, maxSpawnLate);

        spawnlate = RandomSpawnLate(minSpawnLate, maxSpawnLate);
    }

    private float RandomSpawnLate(float min, float max)
    {
        return Mathf.Clamp(Random.Range(min, max),clampMin/2, clampMax);
    }
}