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
    private PlayerControl playerControl;
    private ScrollDown scrollDown;
    private ShipState state;
    private SpriteRenderer spriteRenderer;
    private UIController uiController;

    public void Damage(float amount) {
        health -= amount;

        int newSpriteIndex = (shipData.sprites.Length - 2) - (int)Mathf.Lerp(0, shipData.sprites.Length - 2, health / shipData.health);

        if (health <= 0) {
            uiController.SetValue("Score", uiController.Store["Score"] + shipData.score);
            state = ShipState.Dead;
            newSpriteIndex = shipData.sprites.Length - 1;
        }

        spriteRenderer.sprite = shipData.sprites[newSpriteIndex];
    }

    public ShipState GetState() {
        return state;
    }

    void Awake() {
        health = shipData.health;
        playerControl = GetComponent<PlayerControl>();
        scrollDown = GetComponent<ScrollDown>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        uiController = UIController.Instance;

        spriteRenderer.sprite = shipData.sprites[0];
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Ship collidingShip = collision.gameObject.GetComponent<Ship>();

        if (collidingShip != null && state != ShipState.Dead) {
            collidingShip.Damage(shipData.collisionDamage);
        }
    }

    void Update() {
        if (state == ShipState.Dead && playerControl == null) {
            scrollDown.enabled = true;
        }
    }
}
