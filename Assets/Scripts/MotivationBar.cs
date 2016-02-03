using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeasureBar))]
public class MotivationBar : MonoBehaviour {

	public event Action MotivationDepleted;

	public float StartingValue = 100.0f;
	public float MotivationDecayPerSecond = 5.0f;
	public float IncrementPerWord = 2.5f;
	public WordsPerMinute wpm;

	private float currentValue;
	private MeasureBar mb;

	// Use this for initialization
	void Start () {
		InputManager.WordFired += InputManager_WordFired;
		mb = GetComponent<MeasureBar>();
		currentValue = StartingValue;
        StartCoroutine(MotivationDecay());
	}
	
	// Update is called once per frame
	void Update () {
		mb.CurrentValue = currentValue / StartingValue;
	}

	void InputManager_WordFired (string word, bool isRight)
	{
		if (isRight) {
			currentValue = Mathf.Min(StartingValue, currentValue + IncrementPerWord);
		} else {
			currentValue = Mathf.Max(0, currentValue - IncrementPerWord*3.5f);
			CheckMotivation();
		}
	}

	void OnDisable() {
		InputManager.WordFired -= InputManager_WordFired;
	}

	IEnumerator MotivationDecay() {
        while (!GameManager.GameStarted)
        {
            yield return new WaitForSeconds(0.2f);
        }
		while(GameManager.GameStarted) {
            if (wpm.Value < wpm.MinimumWpM) {
				currentValue = Mathf.Max(0, currentValue - MotivationDecayPerSecond * 0.2f);
				CheckMotivation();
			}
			yield return new WaitForSeconds(0.2f);
		}
	}

	private void CheckMotivation(){
		if (currentValue <= 0) {
			if (MotivationDepleted != null) MotivationDepleted();
		}
	}
}
