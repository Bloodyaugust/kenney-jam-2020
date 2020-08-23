using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public SOObstacle obstacleData;

    void Awake() {
        Quaternion newRotation = Quaternion.identity;

        newRotation.eulerAngles = new Vector3(0, 0, Random.Range(-180, 180));

        transform.rotation = newRotation;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Ship collidingShip = collision.gameObject.GetComponent<Ship>();

        if (collidingShip != null) {
            collidingShip.Damage(obstacleData.damage);
            Destroy(gameObject);
        }
    }
}
