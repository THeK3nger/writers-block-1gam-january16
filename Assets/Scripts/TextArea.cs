using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System;

[RequireComponent(typeof(Text))]
public class TextArea : MonoBehaviour {

	public TextController test_textDB;

	private Text textUI;
	private int currentLineChar = 1;
	private int currentLines = 0;
	private string fullText = "";

	private const int MAX_CHAR = 40;
	private const int MAX_LINES = 4;

	// Use this for initialization
	void Start () {
		textUI = GetComponent<Text>();
	}

	public void WriteWord(string word) {
		// Save the word in the full text buffer anyway...
		fullText += word + " ";
		// If the word will couse overflow, go to a new line.
		if (CheckOverflow (word)) {
			NewLine ();
		}
		textUI.text += " " + word.Trim();
		currentLineChar += word.Length + 1; // Word length + the space character.
		if (word.Contains("\n")) {
			NewLine();
		}
	}

	bool CheckOverflow (string word) {
		return currentLineChar + word.Length > MAX_CHAR;
	}

	void RemoveFirstLineFromDisplay () {
		textUI.text = String.Join ("\n", textUI.text.Split ('\n').Skip (1).ToArray ());
	}

	void NewLine () {
		textUI.text += "\n";
		currentLines++;
		currentLineChar = 0;
		if (currentLines > MAX_LINES - 1) {
			RemoveFirstLineFromDisplay ();
		}
	}

	public string GetFullText() {
		return fullText;
	}
}
