using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(MeasureBar))]
public class WordsPerMinute : MonoBehaviour {

	public float MinimumWpM = 300.0f;
	public Image FillArea;
	public float UpdateIntervall = 0.25f;

	public float Value
	{
	    get
	    {
	        return movingAvg.Average;
	    }
	}

    private int words = 0;
    private bool started = false;
	private MeasureBar mb;
	private MovingAverage movingAvg;


	// Use this for initialization
    private void Start () {
		InputManager.WordFired += WordEventReceiver;
		mb = GetComponent<MeasureBar>();
		movingAvg = new MovingAverage(5.0f,UpdateIntervall);
	}

    private void WordEventReceiver(string word, bool isRight) {
		if (!started) {
			started = true;
			StartCoroutine(UpdateAverage());
		}
		words+=1;
	}

    private void OnDisable() {
		InputManager.WordFired -= WordEventReceiver;
	}

	// Update is called once per frame
    private void Update () {
	
	}

    private IEnumerator UpdateAverage() {
		while(started && GameManager.GameStarted) {
			var wordPerSecond = movingAvg.Next(words);
			words = 0;
			var wordPerMinute = wordPerSecond * 60.0f;
			mb.CurrentValue = wordPerMinute;
			if (wordPerMinute < MinimumWpM) FillArea.color = new Color(1.0f,0.5f,0.0f);
			if (wordPerMinute < MinimumWpM * 0.8) FillArea.color = Color.red;
			if (wordPerMinute >= MinimumWpM) FillArea.color = Color.green;
			yield return new WaitForSeconds(UpdateIntervall);
		}
	}

	public void Reset() {
		started = false;
		words = 0;
		movingAvg = new MovingAverage(5.0f,UpdateIntervall);
	}
}

internal class MovingAverage {
	/// Approximated Moving Average Counter

	public float Average { get; set; }

	private readonly float intervall;
	private readonly float deltaTime;

	public MovingAverage(float intervall, float deltaTime) {
		this.intervall = intervall;
		this.deltaTime = deltaTime;
	}

	public float Next(float samplesInDeltaTime) {
		Average = Average * (1 - (deltaTime/intervall)) + samplesInDeltaTime / intervall;
		return Average;
	}
}
