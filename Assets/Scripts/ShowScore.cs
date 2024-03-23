using TMPro;
using UnityEngine;

/// <summary>
/// Which score do you want to show
/// </summary>
public enum ScoreType {
    CURRENT,
    HIGH,
}

/// <summary>
/// Put this on any object that needs to show the current score
/// or the high score. Must have a text box component attached.
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
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
        // show the appropriate score
        // this happens every frame so the score is immediately updated and
        // keep up to date.
        if (type == ScoreType.CURRENT) {
            txt.text = Game.Instance.CurScore.ToString();
        }
        else if (type == ScoreType.HIGH) {
            txt.text = Game.Instance.HighScore.ToString();
        }
    }
}
