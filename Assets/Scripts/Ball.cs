using UnityEngine;

/// <summary>
/// Attach this to our ball object.
/// </summary>
[RequireComponent(typeof(Rigidbody)),
 RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour {
    // set in inspector
    public float launchForce;       // force multiplier for launching the ball
    public Menu menu;               // just here so I can trigger the gameover menu when all lives are lost
    public GameObject[] ballLives;  // tie this to the visual GUI ball lives in the HUD

    // private fields
    private Rigidbody rb;           // rigidbody attached to the ball. This is set in Start method
    private AudioSource audioSrc;   // audio source attached to the ball. This is set in Start method
    private int lives;              // number of lives left
    private bool canBeLaunced;      // flag to prevent launching multiple times

    private const int MAX_LIVES = 4;    // const for starting amount of lives. This could have also been put in the Consts class.

    // Life Cycle methods
    private void Start() {
        // initialize private fields. You can use the Start method like a constructor
        lives = MAX_LIVES;
        rb = GetComponent<Rigidbody>();
        audioSrc = GetComponent<AudioSource>();
        canBeLaunced = true;
    }
    private void Update() {
        // grab the input object and check if use is launching the ball
        var input = Game.Instance.input;
        if (canBeLaunced && input.Default.LaunchBall.WasReleasedThisFrame()) {
            // launch the ball
            Launch();
        }
    }
    /// <summary>
    /// Remember, this is called only if the object the ball collided with is a trigger, 
    /// i.e. has the "Is Trigger" box checked on its collider.
    /// </summary>
    /// <param name="other">The collider of the game object the ball collided with</param>
    private void OnTriggerEnter(Collider other) {
        // check the tag of what I collided with. If it is the ball end, play sound and reset ball
        if (other.CompareTag(Consts.Tags.BALL_END)) {
            other.gameObject.GetComponent<AudioSource>().Play();
            ResetBall();
        }
        // if it is a score circle, tell the score circle we hit it.
        // all the logic is in the ScoreCircle class 
        else if (other.CompareTag(Consts.Tags.SCORE_CIRCLE)) {
            var scoreCircle = other.GetComponent<ScoreCircle>();
            scoreCircle.Hit();
        }
    }
    /// <summary>
    /// Remember, this is called only if the object the ball collided with is NOT a trigger, 
    /// i.e. has the "Is Trigger" box UNCHECKED on its collider.
    /// </summary>
    /// <param name="collision">A collision object telling us various properties about the collision, such as contact point and force of collision</param>
    private void OnCollisionEnter(Collision collision) {
        // we get the game object from the collision object, then check if it has the Bumper class.
        // if so, it must be a bumper.
        var bumper = collision.gameObject.GetComponent<Bumper>();
        if (bumper != null) {
            // Tell the bumper we hit it. We could have also put the score increase into the Bump method of the Bumper class, either way.
            bumper.Bump();
            Game.Instance.AddScore(Consts.Points.HIT_BUMPER);
        }
        // if we didn't hit a bumper, did we hit a flipper?
        else if (collision.gameObject.tag.StartsWith(Consts.Tags.FLIPPER)) {
            // if so, add a small amount of points
            Game.Instance.AddScore(Consts.Points.HIT_FLIPPER);
        }
    }

    // Other methods
    public void Launch() {
        // add force in the direction the ball needs to go
        float actualLaunchForce = Random.Range(launchForce * 0.8f, launchForce * 1.2f);
        rb.AddForce(Vector3.forward * actualLaunchForce, ForceMode.Impulse);

        // prevent it from being launched again.
        // This might be problematic if the force isn't high enough to get the ball
        // into the game board.
        // canBeLaunched is set back to true when ball is reset
        canBeLaunced = false;

        // play launch audio clip. The proper clip is already set in the AudioSource in Unity's inspector
        audioSrc.Play();
    }
    public void ResetBall() {
        // reset the ball's position and clear any lingering velocity
        transform.position = GameObject.FindGameObjectWithTag(Consts.Tags.BALL_START).transform.position;
        rb.velocity = Vector3.zero;

        // decrement lives and update lives GUI
        ballLives[MAX_LIVES - lives].SetActive(false);
        lives--;

        // show game over if no lives are left
        if (lives <= 0) {
            menu.GameOver();
        }
        // if not game over, allow the ball to be launched again
        else {
            canBeLaunced = true;
        }
    }
    public void RestartGame() {
        // reset the ball's position and clear any lingering velocity
        transform.position = GameObject.FindGameObjectWithTag(Consts.Tags.BALL_START).transform.position;
        rb.velocity = Vector3.zero;

        // reset lives and update lives GUI
        lives = MAX_LIVES;
        for (int i = 0; i < MAX_LIVES; i++) {
            ballLives[i].SetActive(true);
        }

        // allow the ball to be launched
        canBeLaunced = true;
    }
}
