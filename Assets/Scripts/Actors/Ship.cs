using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipState {
    Idle,
    Dead
}

public class Ship : MonoBehaviour {
    public SOShip shipData;

    private float health;
    private ShipState state;

    public void Damage(float amount) {
        health -= amount;

        if (health <= 0) {
            state = ShipState.Dead;
        }
    }

    void Awake() {
        health = shipData.health;
    }

    void Update() {
        if (state == ShipState.Dead) {
            Destroy(gameObject);
        }
    }
}
