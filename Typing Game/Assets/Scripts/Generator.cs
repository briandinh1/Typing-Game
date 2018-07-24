using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    private string[] words;
    public TextAsset asset;

    // Use this for initialization
    void Start() {
        words = asset.text.Split("\n"[0]);
    }

    public string GetRandomWord() {
        return words[Random.Range(0, words.Length)];
    }
}
