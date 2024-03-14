using UnityEngine;

public class Ball : MonoBehaviour {
    private Rigidbody rb;
    public float launchForce = 10;
    private Vector3 initPos;

    public void Launch() {
        rb.AddForce(Vector3.forward * launchForce, ForceMode.Impulse);
    }

    void Start() {
        initPos = GameObject.FindGameObjectWithTag("BallStart").transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("BallEnd")) {
            transform.position = initPos;
            rb.velocity = Vector3.zero;
        }
    }
}
