using UnityEngine;

[RequireComponent(typeof(Rigidbody)),
    RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour {
    // set in inspector
    public float launchForce;
    public Menu menu;
    public GameObject[] ballLives;

    // private fields
    private Rigidbody rb;
    private AudioSource audioSrc;
    private int lives;
    private bool canBeLaunced;

    private const int MAX_LIVES = 4;

    // Life Cycle methods
    private void Start() {
        lives = MAX_LIVES;
        rb = GetComponent<Rigidbody>();
        canBeLaunced = true;
    }
    private void Update() {
        var input = Game.Instance.input;
        if (canBeLaunced && input.Default.LaunchBall.WasReleasedThisFrame()) {
            Launch();
            canBeLaunced = false;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(Consts.Tags.BALL_END)) {
            ResetBall();
        }
        else if (other.CompareTag(Consts.Tags.SCORE_CIRCLE)) {
            bool scoreCircleActive = other.gameObject.GetComponent<ScoreCircle>().isActive;
            int score = scoreCircleActive ? Consts.Points.HIT_SCORE_CIRCLE_ACTIVE : Consts.Points.HIT_SCORE_CIRCLE_NORMAL;
            Game.Instance.AddScore(score);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        var bumper = collision.gameObject.GetComponent<Bumper>();
        if (bumper != null) {
            bumper.Bump();
            Game.Instance.AddScore(Consts.Points.HIT_BUMPER);
        }
        else {
            if (collision.gameObject.tag.StartsWith(Consts.Tags.FLIPPER)) {
                Game.Instance.AddScore(Consts.Points.HIT_FLIPPER);
            }
        }
    }

    // Other methods
    public void Launch() {
        float actualLaunchForce = Random.Range(launchForce * 0.8f, launchForce * 1.2f);
        rb.AddForce(Vector3.forward * actualLaunchForce, ForceMode.Impulse);
        canBeLaunced = false;
        audioSrc.Play();
    }
    public void ResetBall() {
        transform.position = GameObject.FindGameObjectWithTag(Consts.Tags.BALL_START).transform.position;
        rb.velocity = Vector3.zero;
        ballLives[MAX_LIVES - lives].SetActive(false);
        lives--;
        if (lives <= 0) {
            menu.GameOver();
        }
        canBeLaunced = true;
    }
    public void RestartGame() {
        transform.position = GameObject.FindGameObjectWithTag(Consts.Tags.BALL_START).transform.position;
        rb.velocity = Vector3.zero;
        lives = MAX_LIVES;
        for (int i = 0; i < MAX_LIVES; i++) {
            ballLives[i].SetActive(true);
        }
        canBeLaunced = true;
    }
}
