using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject mainMenu;
    public GameObject gameoverMenu;

    void Start() {
        mainMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        Game.Instance.input.Disable();
    }

    public void StartGame() {
        mainMenu.SetActive(false);
        Game.Instance.input.Enable();
    }

    public void GameOver() {
        gameoverMenu.SetActive(true);
        Game.Instance.input.Disable();
    }

    public void Restart() {
        gameoverMenu.SetActive(false);
        Game.Instance.input.Enable();
    }
}
