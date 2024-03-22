using UnityEngine;

public class Game : MonoBehaviour {
    // set in inspector
    public Ball ball;

    // other fields and properties
    [HideInInspector] public PinballInput input;

    public static Game Instance { get; private set; }
    public int CurScore { get; private set; }
    public int HighScore { get; private set; }

    // Life Cycle methods
    private void Awake() {
        input = new PinballInput();
        input.Enable();
        Instance = this;
    }
    private void Start() {
        HighScore = PlayerPrefs.GetInt(Consts.PlayerPrefs.HIGHSCORE, 0);
    }
    private void OnDisable() {
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
