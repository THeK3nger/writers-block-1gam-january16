using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class WordsButton : MonoBehaviour {

	public KeyCode KeyboardKey;

	private Text buttonText;
	private string currentWord;
	private bool isRight;

	private InputManager inputParent;

	// Use this for initialization
	void Start () {
		buttonText = GetComponentInChildren<Text>();
		inputParent = transform.parent.gameObject.GetComponent<InputManager>();
	}
	
	public void SetWord(string word, bool isRight) {
		currentWord = word;
		buttonText.text = word.Trim();
		this.isRight = isRight;
	}

	public void ClickClock() {
		inputParent.ReceiveWord(currentWord, isRight);
	}
}
