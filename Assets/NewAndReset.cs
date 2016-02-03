using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NewAndReset : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NewAndResetClick() {
		Debug.Log("CLICK!");
		FindObjectOfType<StatsRecorder>().Reset();
		SceneManager.LoadScene("MainScene");
	}
}
