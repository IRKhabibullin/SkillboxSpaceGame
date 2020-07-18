using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProblemsGenerator : MonoBehaviour {

    [SerializeField] private float gWidth = 40f;
    [SerializeField] private float gDistance = 300f;
    [SerializeField] private float asteroidGenerationPeriod = 3f;
    [SerializeField] private float enemyGenerationPeriod = 10f;
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private GameObject[] enemyPrefabs;

    private float lastAsteroidGeneratedTime;
    private float lastEnemyGeneratedTime;

    void Start() {
        lastAsteroidGeneratedTime = 0f;
        lastEnemyGeneratedTime = 0f;
    }

    void Update() {
        GenerateAsteroid();
        GenerateEnemy();
    }

    private void GenerateAsteroid() {
        if (Time.time > lastAsteroidGeneratedTime + asteroidGenerationPeriod) {
            Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)], new Vector3(Random.Range(-gWidth, gWidth), 0f, gDistance), Quaternion.identity);
            lastAsteroidGeneratedTime = Time.time;
        }
    }

    private void GenerateEnemy() {
        if (Time.time > lastEnemyGeneratedTime + enemyGenerationPeriod) {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], new Vector3(Random.Range(-gWidth, gWidth), 0f, gDistance), Quaternion.identity);
            lastEnemyGeneratedTime = Time.time;
        }
    }
}
