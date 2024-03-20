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
    private const int MAX_LIVES = 10000;

    void Start() {
        lives = MAX_LIVES;
        rb = GetComponent<Rigidbody>();
    }

    public void Launch() {
        float actualLaunchForce = Random.Range(launchForce * 0.8f, launchForce * 1.2f);
        rb.AddForce(Vector3.forward * actualLaunchForce, ForceMode.Impulse);
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
        var bumper = collision.gameObject.GetComponent<Bumper>();
        if (bumper != null) {
            bumper.Bump();
            Game.Instance.AddScore(100);
        }
        else {
            if (collision.gameObject.tag.StartsWith("Flipper")) {
                Game.Instance.AddScore(10);
            }
            else if (collision.gameObject.CompareTag("ScoreCircle")) {
                print("here");
                int score = collision.gameObject.GetComponent<ScoreCircle>().isActive ? 100_000 : 5;
                Game.Instance.AddScore(score);
            }
        }
    }
}
