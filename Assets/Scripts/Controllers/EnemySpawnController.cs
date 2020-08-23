using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {
    public float SpawnInterval;
    public SOEnemySpawnTable spawnTable;

    private bool spawning;
    private UIController uiController;

    float timeToSpawn;

    void Awake() {
        uiController = UIController.Instance;

        uiController.StoreUpdated += OnStoreUpdated;
    }

    int Roll(int[] dice) {
        int accumulator = 0;

        for (int i = 0; i < dice.Length; i++) {
            accumulator += Random.Range(1, dice[i] + 1);
        }

        return accumulator;
    }

    void OnStoreUpdated(string storeKey) {
        if (storeKey == "GameState") {
            if (uiController.Store[storeKey] == GameState.Menu) {
                spawning = false;
            } else {
                spawning = true;
            }
        }
    }

    void Spawn() {
        int result = Mathf.Clamp(Roll(spawnTable.dice), 0, spawnTable.maxIndex);

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
        if (spawning) {
            timeToSpawn -= Time.deltaTime;

            if (timeToSpawn <= 0) {
                timeToSpawn = SpawnInterval;

                Spawn();
            }
        }
    }
}
