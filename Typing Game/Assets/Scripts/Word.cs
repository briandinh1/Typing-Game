using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// wrapper class for a string (word) with some helper functions

// so that the other classes and objects can use this class
[System.Serializable]

// don't need to derive from mono, because just using as a regular class
public class Word { //: MonoBehaviour {

    public string word;
    private int currIndex;
    private Display display; // the UI element corresponding to this word

    // Use this for initialization
    void Start() {
        currIndex = 0;
    }

    public Word(string _word, Display _display, float fallSpeed) {  
        word = _word;
        display = _display;
        display.SetWord(this, fallSpeed);
    }

    public char GetNextLetter() {
        return word[currIndex];
    }

    // on a successful hit, increment the current index, 
    // then remove the letter from the word on screen
    public void TypeLetter() {
        ++currIndex;
        display.RemoveLetter();
    }

    // destroy game object if fully typed out 
    public bool IsComplete() {
        bool complete = currIndex >= word.Length -1; // skip newline at the end
        if (complete) ClearWord();
        return complete;
    }

    // used to both remove a single word and wipe the screen after game over
    public void ClearWord() {
        display.RemoveWord();
    }
}
