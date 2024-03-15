using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
    private Rigidbody rb;
    public float launchForce;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    public void Launch() {
        rb.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
    }
}
