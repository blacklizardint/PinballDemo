using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour {
    private TextMeshProUGUI txt;
    private int currentScore;
    public HighScore highScore;

    void Start() {
        txt = GetComponent<TextMeshProUGUI>();
        currentScore = PlayerPrefs.GetInt("highscore", 0);
    }

    void Update() {
        txt.text = currentScore.ToString();
    }

    public void AddScore(int amount) {
        currentScore += amount;
        highScore.SubmitScore(currentScore);
    }


}
