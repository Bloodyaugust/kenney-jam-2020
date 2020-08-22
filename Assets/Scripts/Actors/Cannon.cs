using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CannonState {
    Reloading,
    Firing
}

public class Cannon : MonoBehaviour {
    public GameObject ProjectilePrefab;
    public SOCannon cannonData;

    private CannonState state;
    private float timeToFire;
    private float timeToReload;
    private int clipRemaining;

    void Fire() {
        Projectile projectile = Instantiate(ProjectilePrefab, transform.position, transform.rotation).GetComponent<Projectile>();
        projectile.Initialize(cannonData.projectile);

        clipRemaining--;
        timeToFire = cannonData.fireInterval;

        if (clipRemaining <= 0) {
            ReloadBegin();
        }
    }

    void ReloadBegin() {
        state = CannonState.Reloading;
        timeToReload = cannonData.reload;
    }

    void ReloadEnd() {
        clipRemaining = cannonData.clip;
        state = CannonState.Firing;
        timeToFire = 0;
    }

    void Start() {
        clipRemaining = cannonData.clip;
        state = CannonState.Firing;
    }

    void Update() {
        if (state == CannonState.Firing) {
            timeToFire -= Time.deltaTime;

            if (timeToFire <= 0) {
                Fire();
            }
        }

        if (state == CannonState.Reloading) {
            timeToReload -= Time.deltaTime;

            if (timeToReload <= 0) {
                ReloadEnd();
            }
        }
    }
}
