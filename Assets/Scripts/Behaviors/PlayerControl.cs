using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour {
    public float[] HorizontalBounds;
    public float[] VerticalBounds;

    private float horizontalMovement;
    private float moveRotation;
    private float verticalMovement;
    private Ship ship;
    private UIController uiController;

    public void OnPlayerMovementLeftRight(InputAction.CallbackContext context) {
        if (context.performed || context.canceled) {
            horizontalMovement = context.ReadValue<float>();
        }
    }

    public void OnPlayerMovementVertical(InputAction.CallbackContext context) {
        if (context.performed || context.canceled) {
            verticalMovement = context.ReadValue<float>();
        }
    }

    void Awake() {
        ship = GetComponent<Ship>();
        uiController = UIController.Instance;

        ship.Died += OnDied;
        uiController.StoreUpdated += OnStoreUpdate;
    }

    void OnDied() {
        uiController.SetValue("GameState", GameState.Menu);
    }

    void OnStoreUpdate(string storeKey) {
        if (storeKey == "GameState") {
            if (uiController.Store[storeKey] == GameState.Playing) {
                ship.Reset();
            }
        }
    }
    
    void Update() {
        if (ship.GetState() != ShipState.Dead) {
            transform.Translate(new Vector3(horizontalMovement * Time.deltaTime * ship.shipData.moveSpeed, verticalMovement * Time.deltaTime * ship.shipData.moveSpeed, 0), Space.World);
        }

        if (horizontalMovement > 0) {
            moveRotation += ship.shipData.rotationSpeed * Time.deltaTime;
        } else if (horizontalMovement < 0) {
            moveRotation -= ship.shipData.rotationSpeed * Time.deltaTime;
        } else {
            if (Mathf.Abs(moveRotation) < ship.shipData.rotationSpeed * Time.deltaTime) {
                moveRotation = 0;
            }

            if (moveRotation > 0) {
                moveRotation -= (ship.shipData.rotationSpeed * 2) * Time.deltaTime;
            } else if (moveRotation < 0) {
                moveRotation += (ship.shipData.rotationSpeed * 2) * Time.deltaTime;
            }
        }

        moveRotation = Mathf.Clamp(moveRotation, -20, 20);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, HorizontalBounds[0], HorizontalBounds[1]), Mathf.Clamp(transform.position.y, VerticalBounds[0], VerticalBounds[1]), transform.position.z);

        if (ship.GetState() != ShipState.Dead) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 - moveRotation));
        }
    }
}
