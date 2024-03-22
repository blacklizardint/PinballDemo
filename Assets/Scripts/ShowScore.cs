using TMPro;
using UnityEngine;

public enum ScoreType {
    CURRENT,
    HIGH,
}

public class ShowScore : MonoBehaviour {
    // set in inspector
    public ScoreType type;

    // private fields
    private TextMeshProUGUI txt;

    // Life Cycle methods
    private void Start() {
        txt = GetComponent<TextMeshProUGUI>();
    }
    private void Update() {
        if (type == ScoreType.CURRENT) {
            txt.text = Game.Instance.CurScore.ToString();
        }
        else if (type == ScoreType.HIGH) {
            txt.text = Game.Instance.HighScore.ToString();
        }
    }
}
