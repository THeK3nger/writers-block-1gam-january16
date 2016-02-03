using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Flashing : MonoBehaviour {

	private Text textComponent;

	// Use this for initialization
	void Start () {
		textComponent = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		textComponent.color = Random.Range (0.0f, 1.0f) < 0.3f ? Color.black : Color.white;
	}
}
