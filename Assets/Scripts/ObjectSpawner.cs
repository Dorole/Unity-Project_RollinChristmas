using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public Vector3 SpawnAreaSize;
    public Color GizmosColor;

    public GameObject ObjectToSpawn;

    private void Awake()
    {
        Vector3 randomSpawnPositon = new Vector3();
        randomSpawnPositon.x = Random.Range(-SpawnAreaSize.x, SpawnAreaSize.x);
        randomSpawnPositon.y = Random.Range(-SpawnAreaSize.y, SpawnAreaSize.y);
        randomSpawnPositon.z = Random.Range(-SpawnAreaSize.z, SpawnAreaSize.z);
        randomSpawnPositon += transform.position;

        SpawnObject(ObjectToSpawn, randomSpawnPositon);
    }

    private void SpawnObject(GameObject objectToSpawn, Vector3 spawnPosition)
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        spawnedObject.transform.SetParent(transform);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawWireCube(transform.position, SpawnAreaSize);
    }

}
