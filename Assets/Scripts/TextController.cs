using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Text controller: get the text on the basis of the current level, receiv input events, send input to text area.
/// </summary>
public class TextController : MonoBehaviour {

	public int Level = 1;
	public TextArea textArea;
	private TextDB text_database;
	private string[] currentText;
	private int servingIdx = 0;

	void Awake() {
		text_database = FindObjectOfType<TextDB>();
	}

	// Use this for initialization
	void Start () {
		LoadText();
	}

	public string GetNextWord() {
		if (servingIdx >= currentText.Length) {
			throw new NoMoreTextException("No More Text!");
		}
		var result = currentText[servingIdx];
		servingIdx++;
		return result;
	}

	public bool TextComplete() {
		return servingIdx == currentText.Length - 1;
	}

	void LoadText() {
		currentText = text_database.ServeText(Level-1);
	}
}

public class NoMoreTextException : Exception {
    public NoMoreTextException() : base() { }
    public NoMoreTextException(string message) : base(message) { }
    public NoMoreTextException(string message, System.Exception inner) : base(message, inner) { }
}
