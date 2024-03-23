using UnityEngine;

/// <summary>
/// Set to LEFT for left flipper (and top flipper)
/// Set to RIGHT for right flipper
/// </summary>
public enum FlipperType {
    LEFT,
    RIGHT,
}

[RequireComponent(typeof(Rigidbody)),
RequireComponent(typeof(AudioSource))]
public class Flipper : MonoBehaviour {
    // set in inspector
    public FlipperType type;
    public float force;         // force applied to get it to flip

    // private fields
    private Rigidbody rb;
    private AudioSource audioSrc;

    // Life Cycle methods
    private void Start() {
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
    }

    private void Update() {
        // Grab input and flip if this is LEFT and left action was pressed.
        // or flip if this is RIGHT and right action was pressed.
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
        // apply force to get it to flip.
        // we use a spring on the Hinge Joint (look at the Inspector) to get it to go back down
        rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
        audioSrc.Play();
    }
}
