using UnityEngine;
using System.Collections.Generic;

public class ItemSpawner : MonoBehaviour
{
    public GameObject paperPrefab;
    public GameObject plasticPrefab;
    public GameObject glassPrefab;

    public int maxItems = 10; 
    public Vector3 spawnArea = new Vector3(10f, 0f, 10f); 

    public float minDistanceFromPlayer = 3f; 
    public float minDistanceBetweenItems = 1f; 

    private GameObject player;
    private List<Vector3> spawnedPositions = new List<Vector3>();

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player == null)
            Debug.LogError("Player not found!");

        SpawnInitialItems();
    }

    void SpawnInitialItems()
    {
        for (int i = 0; i < maxItems; i++)
        {
            SpawnRandomItem();
        }
    }

    public void SpawnRandomItem()
    {
        GameObject prefabToSpawn = null;
        int rand = Random.Range(0, 3); 

        if (rand == 0) prefabToSpawn = paperPrefab;
        else if (rand == 1) prefabToSpawn = plasticPrefab;
        else prefabToSpawn = glassPrefab;

        Vector3 randomPos;
        int attempts = 0;

        
        do
        {
            randomPos = new Vector3(
                Random.Range(-spawnArea.x, spawnArea.x),
                0.5f,
                Random.Range(-spawnArea.z, spawnArea.z)
            );

            attempts++;
            if (attempts > 50) break; 
        }
        while (
            Vector3.Distance(randomPos, player.transform.position) < minDistanceFromPlayer ||
            spawnedPositions.Exists(pos => Vector3.Distance(pos, randomPos) < minDistanceBetweenItems)
        );

        
        spawnedPositions.Add(randomPos);

        Instantiate(prefabToSpawn, randomPos, Quaternion.identity);
    }
}