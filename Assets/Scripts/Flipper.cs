using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour {
    public float flipForce = 30;
    private Rigidbody rb;

    public void Flip() {
        rb.AddForce(Vector3.forward * flipForce, ForceMode.Impulse);
    }

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
}
