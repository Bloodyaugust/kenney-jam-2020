using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    public SOProjectile projectileData;

    public void Initialize(SOProjectile data) {
        projectileData = data;
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Ship collidingShip = collision.gameObject.GetComponent<Ship>();

        if (collidingShip != null) {
            if (collidingShip.GetState() != ShipState.Dead) {
                collidingShip.Damage(projectileData.damage);
                Destroy(gameObject);
            }
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        transform.Translate(Vector3.right * projectileData.speed * Time.deltaTime, Space.Self);
    }
}
