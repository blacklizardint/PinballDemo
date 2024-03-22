using UnityEngine;

public class Menu : MonoBehaviour {
    // set in inspector
    public GameObject mainMenu;
    public GameObject gameoverMenu;

    // Life Cycle methods
    private void Start() {
        mainMenu.SetActive(true);
        gameoverMenu.SetActive(false);
        Game.Instance.input.Disable();
    }

    // Other methods
    public void StartGame() {
        mainMenu.SetActive(false);
        Game.Instance.input.Enable();
    }
    public void GameOver() {
        gameoverMenu.SetActive(true);
        Game.Instance.input.Disable();
    }
    public void RestartGame() {
        gameoverMenu.SetActive(false);
        Game.Instance.input.Enable();
    }
}
