using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour {

    public GameObject wordObject;
    public Transform canvas;

    public Display SpawnWord() {
        Vector3 position = new Vector3(Random.Range(-10f, 10f), 8f);
        GameObject wordObj = Instantiate(wordObject, position, Quaternion.identity, canvas);
        Display display = wordObj.GetComponent<Display>();
        return display;
    }
}
