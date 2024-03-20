using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour {
    private Renderer ren;
    private float t;

    void Start() {
        ren = GetComponent<Renderer>();
        t = 0;
    }

    void Update() {
        if (t > 0) {
            Color color = Color.Lerp(Color.yellow, Color.green, t);
            ren.material.SetColor("_BaseColor", color);
            t -= Time.deltaTime / 2.0f;
            if (t < 0) {
                t = 0;
            }
        }
    }

    public void Bump() {
        ren.material.SetColor("_BaseColor", Color.green);
        t = 1;
    }
}
