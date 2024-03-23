using UnityEngine;

public class ScoreCircle : MonoBehaviour {
    // set in inspector
    public SpriteRenderer spriteRen;
    public AudioClip activeSound;
    public AudioClip inactiveSound;

    // other fields
    private readonly Color inactiveColor = new Color(45 / 255.0f, 97 / 255.0f, 108 / 255.0f);
    private readonly Color activeColor = new Color(121 / 255.0f, 255 / 255.0f, 249 / 255.0f);
    private const float MIN_SWITCH_TIME = 3.0f;
    private const float MAX_SWITCH_TIME = 10.0f;
    private float timeTilSwitch;
    private AudioSource audioSrc;
    private ParticleSystem ps;
    [HideInInspector] public bool isActive;

    // Life Cycle methods
    private void Start() {
        spriteRen.color = inactiveColor;
        timeTilSwitch = Random.Range(MIN_SWITCH_TIME, MAX_SWITCH_TIME);
        isActive = false;
        audioSrc = GetComponent<AudioSource>();
        ps = GetComponentInChildren<ParticleSystem>();
    }
    private void Update() {
        timeTilSwitch -= Time.deltaTime;
        if (timeTilSwitch < 0) {
            isActive = !isActive;
            spriteRen.color = isActive ? activeColor : inactiveColor;
            timeTilSwitch = Random.Range(MIN_SWITCH_TIME, MAX_SWITCH_TIME);
        }
    }

    // Other methods
    public void Hit() {
        int score = isActive ? Consts.Points.HIT_SCORE_CIRCLE_ACTIVE : Consts.Points.HIT_SCORE_CIRCLE_NORMAL;
        Game.Instance.AddScore(score);
        audioSrc.clip = isActive ? activeSound : inactiveSound;
        audioSrc.Play();
        isActive = false;
        spriteRen.color = isActive ? activeColor : inactiveColor;
        ps.Play();
    }
}
