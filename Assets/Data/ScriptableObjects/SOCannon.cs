using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Cannon", order = 1)]
public class SOCannon : ScriptableObject {
    public int clip;
    public float fireInterval;
    public float reload;
    public SOProjectile projectile;
}
