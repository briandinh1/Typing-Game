using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour {

    private GameManager gameManager;

    // Use this for initialization
    void Start() {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update () {
        foreach (char c in Input.inputString)
            gameManager.TypeLetter(c);
	}
}
