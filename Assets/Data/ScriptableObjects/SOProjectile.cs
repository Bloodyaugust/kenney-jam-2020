using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Projectile", order = 1)]
public class SOProjectile : ScriptableObject {
    public float damage;
    public GameObject hitParticleSystemPrefab;
    public string[] flags;
    public float speed;
}
