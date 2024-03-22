using UnityEngine;

public class ScoreCircle : MonoBehaviour {
    // set in inspector
    public SpriteRenderer spriteRen;

    // other fields
    private Color inactiveColor = new Color(45 / 255.0f, 97 / 255.0f, 108 / 255.0f);
    private Color activeColor = new Color(121 / 255.0f, 255 / 255.0f, 249 / 255.0f);
    private float timeTilActive;
    [HideInInspector] public bool isActive;

    // Life Cycle methods
    private void Start() {
        spriteRen.color = inactiveColor;
        timeTilActive = Random.Range(3.0f, 10f);
        isActive = false;
    }
    private void Update() {
        timeTilActive -= Time.deltaTime;
        if (timeTilActive < 0) {
            spriteRen.color = activeColor;
            isActive = true;
        }
    }
}
