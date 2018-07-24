using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// responsible for the showing and removing of words on screen
public class Display : MonoBehaviour {

    public Text text;
    private float fallSpeed;
    private Word word; // current word this object is displaying
    private GameManager gameManager;
    private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
        gameManager = FindObjectOfType<GameManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0f);
	}

    // take a word and put it on the UI canvas
    public void SetWord(Word _word, float _fallSpeed) {
        word = _word;
        text.text = word.word;
        fallSpeed = _fallSpeed;
    }

    public void RemoveLetter() {
        text.text = text.text.Remove(0, 1); // first index
        text.color = Color.red;
    }

    public void RemoveWord() {
        if (word == gameManager.activeWord)
            gameManager.hasActiveWord = false;
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "KillBox") {
            gameManager.words.Remove(word);
            scoreManager.AddStrike();
            RemoveWord();
        }
    }
}
