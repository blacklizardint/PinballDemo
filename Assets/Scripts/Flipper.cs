using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Flipper : MonoBehaviour {
    private Rigidbody rb;
    public float force;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Flip() {
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
