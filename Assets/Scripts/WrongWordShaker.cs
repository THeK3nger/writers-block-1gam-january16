using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Shaker))]
public class WrongWordShaker : MonoBehaviour {

    private Shaker shaker;

	// Use this for initialization
	void Start () {
        InputManager.WordFired += InputManager_WordFired;
        shaker = GetComponent<Shaker>();
	}

    private void InputManager_WordFired(string word, bool isRight)
    {
        if (!isRight)
        {
            shaker.Shake(0.4f);
        }
    }

	void OnDisable() {
		InputManager.WordFired -= InputManager_WordFired;
	}
}
