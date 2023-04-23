using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour {
    public Material material;
    public Vector2 initialOffset;
    public Vector2 frameOffset;
    public float rate;
    public int frameCount;

    private float timer = 0.0f;
    private int frames = 0;

    void Update() {
        timer += Time.deltaTime;
        if(timer > rate) {
            timer = 0.0f;
            material.mainTextureOffset += frameOffset;
            frames++;
        }
        if(frames >= frameCount) {
            frames = 0;
            material.mainTextureOffset = initialOffset;
        }
    }

    void OnApplicationQuit() {
        material.mainTextureOffset = initialOffset;
    }
}
