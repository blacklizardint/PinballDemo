using UnityEngine;

public enum FlipperType {
    LEFT,
    RIGHT,
}

[RequireComponent(typeof(Rigidbody))]
public class Flipper : MonoBehaviour {
    // set in inspector
    public FlipperType type;
    public float force;

    // private fields
    private Rigidbody rb;

    // Life Cycle methods
    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        var input = Game.Instance.input;
        if (type == FlipperType.LEFT && input.Default.FlipperLeft.WasPressedThisFrame()) {
            Flip();
        }
        else if (type == FlipperType.RIGHT && input.Default.FlipperRight.WasPressedThisFrame()) {
            Flip();
        }
    }

    // Other methods
    public void Flip() {
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
    }
}
