using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Ship", order = 1)]
public class SOShip : ScriptableObject {
    public float collisionDamage;
    public float health;
    public float moveSpeed;
    public float rotationSpeed;
    public Sprite[] sprites;
}
