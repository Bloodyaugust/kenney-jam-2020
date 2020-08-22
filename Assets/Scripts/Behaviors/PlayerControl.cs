using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour {
    public float MoveSpeed;
    public float RotationSpeed;
    public float[] HorizontalBounds;
    public float[] VerticalBounds;

    private float horizontalMovement;
    private float moveRotation;
    private float verticalMovement;

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
    
    void Update() {
        transform.Translate(new Vector3(horizontalMovement * Time.deltaTime * MoveSpeed, verticalMovement * Time.deltaTime * MoveSpeed, 0), Space.World);

        if (horizontalMovement > 0) {
            moveRotation += RotationSpeed * Time.deltaTime;
        } else if (horizontalMovement < 0) {
            moveRotation -= RotationSpeed * Time.deltaTime;
        } else {
            if (Mathf.Abs(moveRotation) < 0.001f) {
                moveRotation = 0;
            }

            if (moveRotation > 0) {
                moveRotation -= (RotationSpeed * 2) * Time.deltaTime;
            } else if (moveRotation < 0) {
                moveRotation += (RotationSpeed * 2) * Time.deltaTime;
            }
        }

        moveRotation = Mathf.Clamp(moveRotation, -20, 20);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, HorizontalBounds[0], HorizontalBounds[1]), Mathf.Clamp(transform.position.y, VerticalBounds[0], VerticalBounds[1]), transform.position.z);
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90 - moveRotation));
    }
}
