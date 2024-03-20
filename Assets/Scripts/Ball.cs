using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour {
    // set in inspector
    public float launchForce;
    public Menu menu;

    // private fields
    private Rigidbody rb;
    private int lives;
    private const int MAX_LIVES = 0;

    void Start() {
        lives = MAX_LIVES;
        rb = GetComponent<Rigidbody>();
    }

    public void Launch() {
        rb.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
    }
    public void Restart() {
        transform.position = GameObject.FindGameObjectWithTag("BallStart").transform.position;
        rb.velocity = Vector3.zero;
        lives = MAX_LIVES;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BallEnd")) {
            transform.position = GameObject.FindGameObjectWithTag("BallStart").transform.position;
            rb.velocity = Vector3.zero;
            lives--;
            print($"number of balls left: {lives}");
            if (lives < 0) {
                menu.GameOver();
            }
        }
    }
    private void OnCollisionEnter(Collision collision) {
        print("you collided");
        var bumper = collision.gameObject.GetComponent<Bumper>();
        if (bumper != null) {
            bumper.Bump();
        }
    }
}
