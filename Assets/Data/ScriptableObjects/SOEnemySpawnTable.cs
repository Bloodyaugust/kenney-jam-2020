using System;
using UnityEngine;

[Serializable]
public class RangeArray {
    public int[] Range;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Enemy Spawn Table", order = 1)]
public class SOEnemySpawnTable : ScriptableObject {
    public int maxIndex;
    public GameObject[] spawnPrefabs;
    public RangeArray[] spawnRanges;
}
