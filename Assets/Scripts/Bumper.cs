using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bumper : MonoBehaviour {
    // private fields
    private Renderer ren;
    private AudioSource audioSrc;
    private float t;
    private readonly Color ColorHit = Color.green;
    private readonly Color ColorDefault = Color.white;

    // Life Cycle methods
    private void Start() {
        ren = GetComponent<Renderer>();
        audioSrc = GetComponent<AudioSource>();
        t = 0;
    }
    private void Update() {
        // transition color back to default after being hit
        if (t > 0) {
            Color color = Color.Lerp(ColorDefault, ColorHit, t);
            ren.material.SetColor("_BaseColor", color);
            // the divided by 2 just slows it down some
            t -= Time.deltaTime / 2.0f;
            if (t < 0) {
                t = 0;
            }
        }
    }

    // Other methods
    public void Bump() {
        // change to hit color
        ren.material.SetColor("_BaseColor", ColorHit);

        // allow Update method to transition it slowly back to default color
        t = 1;

        // play sound
        audioSrc.Play();
    }
}
