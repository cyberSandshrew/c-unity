using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class terrainspwan : MonoBehaviour
{
    public GameObject enemyPrefab; // drag the enemy prefab into this field in the inspector
    public float spawnInterval = 5.0f; // the time between each spawn
    public float spawnHeight = 10.0f; // the height above the terrain to spawn the enemy
    public int maxEnemies = 10; // the maximum number of enemies that can be spawned

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            // reset the timer
            timeSinceLastSpawn = 0.0f;

            // check if we have reached the maximum number of enemies
            if (GameObject.FindGameObjectsWithTag("enemy").Length >= maxEnemies)
            {
                return;
            }

            // generate a random position above the terrain
            float x = Random.Range(-1000.0f, 1000.0f);
            float z = Random.Range(-1000.0f, 1000.0f);
            float y = Terrain.activeTerrain.SampleHeight(new Vector3(x, 0, z)) + spawnHeight;
            Vector3 spawnPosition = new Vector3(x, y, z);

            // spawn the enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
