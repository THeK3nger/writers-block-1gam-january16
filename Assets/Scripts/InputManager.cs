using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class InputManager : MonoBehaviour {

	public static event Action<string, bool> WordFired;
	public static event Action<bool> GameEnd;

	public TextArea textArea;
	public TextController tc;

	public WordsButton leftButton;
	public WordsButton rightButton;

	readonly string[] randomWords = { "apple", "mango", "papaya", "banana", "guava", "pineapple" };
	readonly System.Random rnd = new System.Random();

	bool receiveReady = false;

	// Update is called once per frame
	void Update () {
		if (GameManager.GameStarted) {
			// Handle Keyboard Input
			if (Input.GetKeyDown(leftButton.KeyboardKey)) {
				leftButton.ClickClock();
			} else if (Input.GetKeyDown(rightButton.KeyboardKey)) {
				rightButton.ClickClock();
			}
		}
	}

	public void SetupButtons() {
		try {
			string next_word = tc.GetNextWord();
			string random_word = RandomWord();
			Debug.Log(next_word);
			bool trueWordOnRightSide = UnityEngine.Random.Range(0,2) == 0;
			if (trueWordOnRightSide) {
				rightButton.SetWord(next_word, true);
				leftButton.SetWord(random_word, false);
			} else {
				rightButton.SetWord(random_word, false);
				leftButton.SetWord(next_word, true);
			}
			receiveReady = true;
		} catch (NoMoreTextException e) {
			GameManager.GameStarted = false;
			GameEnd(true);
		}
	}

	public void ReceiveWord(string word, bool isRight) {
		if (receiveReady) {
			receiveReady = false;
			textArea.WriteWord(word);
			if (isRight) {
				Debug.Log("Is Right!");
			} else {
				Debug.Log("Is Wrong!");
			}
			SetupButtons();
			if (WordFired!=null) WordFired(word, isRight);
		}
	}
		
	private string RandomWord() {
		return randomWords[rnd.Next(0,randomWords.Length)];
	}
}
