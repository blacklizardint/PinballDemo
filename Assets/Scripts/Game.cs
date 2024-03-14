using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {
    public PinballInput input;
    public Ball ball;
    public Flipper flipperLeft;
    public Flipper flipperRight;

    void Start() {
        input = new PinballInput();
        input.Enable();
    }

    void Update() {
        if (input.Default.FlipperLeft.WasPressedThisFrame()) {
            print("flip");
            flipperLeft.Flip();
        }
        else if (input.Default.FlipperRight.WasPressedThisFrame()) {
            print("flip");
            flipperRight.Flip();
        }
        else if (input.Default.LaunchBall.WasReleasedThisFrame()) {
            print("launch");
            ball.Launch();
        }
    }
}
