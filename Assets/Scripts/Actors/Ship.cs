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
    private SpriteRenderer spriteRenderer;

    public void Damage(float amount) {
        health -= amount;

        int newSpriteIndex = (shipData.sprites.Length - 1) - (int)Mathf.Lerp(0, shipData.sprites.Length - 1, health / shipData.health);

        spriteRenderer.sprite = shipData.sprites[newSpriteIndex];

        if (health <= 0) {
            state = ShipState.Dead;
        }
    }

    void Awake() {
        health = shipData.health;
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = shipData.sprites[0];
    }

    void Update() {
        if (state == ShipState.Dead) {
            Destroy(gameObject);
        }
    }
}
