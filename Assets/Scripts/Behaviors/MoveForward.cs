using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
    private Ship ship;

    void Awake() {
        ship = GetComponent<Ship>();
    }

    void Update() {
        if (ship.GetState() != ShipState.Dead) {
            transform.Translate(transform.up * ship.shipData.moveSpeed * Time.deltaTime);
        }
    }
}
