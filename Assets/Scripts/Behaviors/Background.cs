using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public float ScrollSpeed;

    private float yOffset;
    private SpriteRenderer spriteRenderer;

    void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() {
        yOffset += Time.deltaTime * ScrollSpeed;

        spriteRenderer.material.mainTextureOffset = new Vector2(0, yOffset);
    }
}
