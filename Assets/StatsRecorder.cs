using UnityEngine;
using System.Collections;

public class StatsRecorder : MonoBehaviour {

    public int WordsTyped = 0;

    public int WrongWords = 0;

    private float elapsedTime = 0.0f;

	public bool win = false;

	public string fullText;

	// Use this for initialization
	void Start ()
	{
		InputManager.WordFired += InputManager_WordFired;
		InputManager.GameEnd += InputManager_GameEnd;
	}

	void InputManager_GameEnd (bool winning)
	{
		win = winning;
	}

	void InputManager_WordFired (string word, bool isRight)
	{
		WordsTyped+=1;
		if (!isRight) {
			WrongWords+=1;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnDisable() {
		InputManager.WordFired -= InputManager_WordFired;
		InputManager.GameEnd -= InputManager_GameEnd;
	}

    public void Reset()
    {
        WordsTyped = 0;
        WrongWords = 0;
        elapsedTime = 0.0f;
		win = false;
    }


}
