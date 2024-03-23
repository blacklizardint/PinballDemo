using UnityEngine;

public class Game : MonoBehaviour {
    // set in inspector
    public Ball ball;

    // other fields and properties
    [HideInInspector] public PinballInput input;

    /// <summary>
    /// Our Singleton instance. This allows all classes to refer to the game but
    /// simply using Game.Instance
    /// </summary>
    public static Game Instance { get; private set; }

    // scores
    public int CurScore { get; private set; }
    public int HighScore { get; private set; }

    // Life Cycle methods
    private void Awake() {
        // create new input object and enable by default.
        input = new PinballInput();
        input.Enable();

        // set the singleton instance. Don't forget to do this!
        // if you forget, all references to Game.Instance will be null.
        Instance = this;
    }
    private void Start() {
        // grab high score when game starts
        HighScore = PlayerPrefs.GetInt(Consts.PlayerPrefs.HIGHSCORE, 0);
    }
    private void OnDisable() {
        // if game is disabled (for example if the player quits the game), save
        // the high score
        PlayerPrefs.SetInt(Consts.PlayerPrefs.HIGHSCORE, HighScore);
    }

    // Other methods
    public void AddScore(int amount) {
        CurScore += amount;
        if (CurScore > HighScore) {
            HighScore = CurScore;
        }
    }
}
