using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnItmes : MonoBehaviour
{
    public GameObject[] itemPrefab;
    public int itemCount;
    public Vector3 spawnCenterPoint;
    public float spawnRadius;
    private int idx;
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < itemCount; i++)
        {
            Vector3 randomPosition = new Vector3(
                Random.Range( spawnCenterPoint.x - spawnRadius, spawnCenterPoint.x + spawnRadius),
                Random.Range( spawnCenterPoint.y - spawnRadius, spawnCenterPoint.y + spawnRadius),
                Random.Range( spawnCenterPoint.z - spawnRadius, spawnCenterPoint.z + spawnRadius)
            );
            idx = Random.Range(0, itemPrefab.Length);
            Instantiate(itemPrefab[idx], randomPosition, Quaternion.identity).transform.SetParent(transform);
        }
    }
}
