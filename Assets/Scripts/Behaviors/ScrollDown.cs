using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollDown : MonoBehaviour {
    public float ScrollSpeed;

    void Update() {
        transform.Translate(transform.up * -1 * Time.deltaTime);
    }
}
