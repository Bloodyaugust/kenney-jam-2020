using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour {
    public float ScrollSpeed;

    void Update() {
        transform.Translate(Vector3.down * Time.deltaTime, Space.World);
    }
}
