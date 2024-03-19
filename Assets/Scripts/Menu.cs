using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    public GameObject mainMenu;

    void Start() {
        mainMenu.SetActive(true);
        Game.Instance.input.Disable();
    }

    public void StartGame() {
        mainMenu.SetActive(false);
        Game.Instance.input.Enable();
    }
}
