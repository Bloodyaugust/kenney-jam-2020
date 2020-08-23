using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    public float SpawnInterval;
    public SOEnemySpawnTable spawnTable;

    float timeToSpawn;

    int Roll(int[] dice) {
        int accumulator = 0;

        for (int i = 0; i < dice.Length; i++) {
            accumulator += Random.Range(1, dice[i] + 1);
        }

        return accumulator;
    }

    void Spawn() {
        int result = Mathf.Clamp(Roll(new int[3] { 6, 6, 3 }), 0, spawnTable.maxIndex);

        for (int i = 0; i < spawnTable.spawnRanges.Length; i++) {
            RangeArray range = spawnTable.spawnRanges[i];

            if (result >= range.Range[0] && result <= range.Range[1]) {
                GameObject newEnemy = Instantiate(spawnTable.spawnPrefabs[i], new Vector3(Random.Range(-2.5f, 2.5f), 7.5f, 0), spawnTable.spawnPrefabs[i].transform.rotation);
                break;
            }
        }
    }

    void Start() {
        timeToSpawn = SpawnInterval;
    }

    void Update() {
        timeToSpawn -= Time.deltaTime;

        if (timeToSpawn <= 0) {
            timeToSpawn = SpawnInterval;

            Spawn();
        }
    }
}
