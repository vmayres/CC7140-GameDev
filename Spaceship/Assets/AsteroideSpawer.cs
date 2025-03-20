using System.Collections;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidPrefabs; // Array com os 3 prefabs de asteroides
    public float minY = -3.5f; // Posição mínima de spawn no eixo Y
    public float maxY = 3.5f;  // Posição máxima de spawn no eixo Y
    public float minSpawnTime = 1f; // Tempo mínimo entre spawns
    public float maxSpawnTime = 2.5f; // Tempo máximo entre spawns
    public float minScale = 1.0f; // Escala mínima (100%)
    public float maxScale = 1.3f; // Escala máxima (130%)
    public int minAsteroids = 1; // Mínimo de asteroides gerados por vez
    public int maxAsteroids = 3; // Máximo de asteroides gerados por vez

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            int asteroidCount = Random.Range(minAsteroids, maxAsteroids + 1); // Define quantos asteroides spawnar (1 a 3)

            for (int i = 0; i < asteroidCount; i++)
            {
                SpawnSingleAsteroid();
            }

            float waitTime = Random.Range(minSpawnTime, maxSpawnTime); // Tempo aleatório entre os spawns
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnSingleAsteroid()
    {
        float spawnY = Random.Range(minY, maxY); // Posição Y aleatória
        int randomIndex = Random.Range(0, asteroidPrefabs.Length); // Escolhe um prefab aleatório
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnY, transform.position.z);

        GameObject asteroid = Instantiate(asteroidPrefabs[randomIndex], spawnPosition, Quaternion.identity);

        // Define a escala aleatória entre 100% e 130%
        float randomScale = Random.Range(minScale, maxScale);
        asteroid.transform.localScale *= randomScale;
    }
}
