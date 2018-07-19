using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private string[] wordList; // the list of words pulled from the txt file
    public List<Word> words; // the current words in the game
    public Word activeWord;
    public bool hasActiveWord;
    public SpawnHandler spawnHandler;
    public AudioSource hitSound;
    private ScoreManager scoreManager;
    public TextAsset asset;
    public bool gameOver;
    private TimeKeeper timeKeeper;
    public float fallSpeed; // how fast a word moves down the screen

    // Use this for initialization
    void Start() {
        gameOver = false;
        wordList = asset.text.Split("\n"[0]);
        timeKeeper = FindObjectOfType<TimeKeeper>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update() {
        if (gameOver) StartCoroutine(Reset());
    }

    // wipe words left on screen, destroy their game objects
    // wait 3 seconds to allow breathing room, then reset the game
    private IEnumerator Reset() {
        foreach (Word word in words)
            word.ClearWord();
        words.Clear();
        yield return new WaitForSeconds(3f);
        scoreManager.ResetScore();
        timeKeeper.ResetTime();
        gameOver = false;
    }

    public void AddWord() {
        if (!gameOver) { // failsafe for coroutine // don't add words when game is over
            float speed = Random.Range(fallSpeed / 2, fallSpeed * 1.5f);
            Word word = new Word(wordList[Random.Range(0, wordList.Length)],
                 spawnHandler.SpawnWord(), speed);
            words.Add(word);
        }
    }

    public void TypeLetter(char c) {
        if (hasActiveWord) {
            if (activeWord.GetNextLetter() == c) {
                activeWord.TypeLetter();
                if (hitSound.isPlaying) hitSound.Stop(); // prevents multiple sounds overloading
                hitSound.Play();
                scoreManager.AddScore();
            }
        }
        else {
            foreach (Word word in words) {
                if (word.GetNextLetter() == c) {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    if (hitSound.isPlaying) hitSound.Stop(); // prevents multiple sounds overloading
                    hitSound.Play();
                    scoreManager.AddScore();
                    break;
                }
            }
        }

        if (hasActiveWord && activeWord.IsComplete())
            words.Remove(activeWord);
    }
}
