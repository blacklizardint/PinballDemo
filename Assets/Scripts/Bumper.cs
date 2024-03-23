using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bumper : MonoBehaviour {
    // private fields
    private Renderer ren;
    private AudioSource audioSrc;
    private float t;

    // Life Cycle methods
    private void Start() {
        ren = GetComponent<Renderer>();
        audioSrc = GetComponent<AudioSource>();
        t = 0;
    }
    private void Update() {
        if (t > 0) {
            Color color = Color.Lerp(Color.yellow, Color.green, t);
            ren.material.SetColor("_BaseColor", color);
            t -= Time.deltaTime / 2.0f;
            if (t < 0) {
                t = 0;
            }
        }
    }

    // Other methods
    public void Bump() {
        ren.material.SetColor("_BaseColor", Color.green);
        t = 1;
        audioSrc.Play();
    }
}
