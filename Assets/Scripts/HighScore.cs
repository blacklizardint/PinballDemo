using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
class HighScoreRecord {
    public int score;
    public string name;
}

public class HighScore : MonoBehaviour {
    private TextMeshProUGUI txt;
    private int highScore;


    void Start() {
        highScore = 0;
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update() {
        txt.text = highScore.ToString();
    }

    public void SubmitScore(int score) {
        if (highScore < score) {
            highScore = score;
            PlayerPrefs.SetInt("highscore", highScore);
        }
    }

    public void ResetScore() {
        PlayerPrefs.DeleteKey("highscore");
    }
}
