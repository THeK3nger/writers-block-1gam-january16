using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreWriter : MonoBehaviour {

	public Text GameOverText;
	public Text WordsLabel;
	public Text AccuracyLabel;
	public Text BackgroundText;

	// Use this for initialization
	void Start () {
		var score = FindObjectOfType<StatsRecorder>();
		var rightWords = score.WordsTyped - score.WrongWords;
		if (score.win) {
			GameOverText.text = "You Win!";
		}
		WordsLabel.text = rightWords.ToString();
		AccuracyLabel.text = Mathf.Floor(100f*rightWords/score.WordsTyped) + "%";
		BackgroundText.text = score.fullText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
