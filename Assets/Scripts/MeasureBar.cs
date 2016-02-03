using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MeasureBar : MonoBehaviour {

	public float MaxValue =  1000;

	public float CurrentValue = 0;

	private Slider slider;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider>();
	}
		
	void Update() {
		slider.value = CurrentValue/MaxValue;
	}
}
