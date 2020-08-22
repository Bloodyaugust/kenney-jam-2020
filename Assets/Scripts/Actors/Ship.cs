using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipState {
    Idle,
    Dead
}

public class Ship : MonoBehaviour {
    public SOShip shipData;

    private ShipState state;
}
