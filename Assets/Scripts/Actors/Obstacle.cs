using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {
    public SOObstacle obstacleData;

    void OnCollisionEnter2D(Collision2D collision) {
        Ship collidingShip = collision.gameObject.GetComponent<Ship>();

        if (collidingShip != null) {
            collidingShip.Damage(obstacleData.damage);
        }
    }
}
