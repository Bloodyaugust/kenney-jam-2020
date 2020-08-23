using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCameraLeave : MonoBehaviour {
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
