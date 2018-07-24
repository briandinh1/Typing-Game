using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeKeeper : MonoBehaviour {

    private GameManager gameManager;
    private float baseDelay; // used to reset the game
    public float spawnDelay;
    public float delayMultiplier; // will get faster and faster over time
    private float nextSpawnTime;

    // Use this for initialization
    void Start () {
        nextSpawnTime = 0f;
        baseDelay = spawnDelay;
        gameManager = FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= nextSpawnTime) {
            gameManager.AddWord();
            nextSpawnTime = Time.time + spawnDelay;
            spawnDelay *= delayMultiplier;
        }      
    }

    // reset time to base values after game over
    public void ResetTime() {
        spawnDelay = baseDelay;
    }
}
