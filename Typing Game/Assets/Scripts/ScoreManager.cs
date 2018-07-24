using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public float scoreAwarded;
    public float currentScore;
    public Text currentScoreUI;
    public float highScore;
    public Text highScoreUI;
    public Text[] strikes;
    private int currentStrike;
    private GameManager gameManager;
    public AudioSource strikeSound;

    // Use this for initialization
    void Start () {
        highScoreUI.text = "0";
        ResetScore();
        gameManager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    // reset score after game over
    public void ResetScore() {
        for (int i = 0; i < 3; i++) {
            strikes[i].color = Color.white;
            strikes[i].text = "o";
        }
        currentStrike = 0;
        currentScoreUI.text = "0";
    }

    public void AddStrike() {
        strikes[currentStrike].color = Color.red;
        strikes[currentStrike++].text = "X";
        if (strikeSound.isPlaying) strikeSound.Stop(); // prevents multiple sounds overloading
        strikeSound.Play();
        if (currentStrike >= 3)
            gameManager.gameOver = true;
    }

    public void AddScore() {
        currentScore += scoreAwarded;
        if (currentScore > highScore)
            highScore = currentScore;

        currentScoreUI.text = "" + Mathf.Round(currentScore);
        highScoreUI.text = "" + Mathf.Round(highScore);
    }
}
