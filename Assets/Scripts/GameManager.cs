using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	public InputManager InputManagerInstance;
	public StatsRecorder StatsRecorderInstance;
	public MotivationBar motivationBar;
	public GameObject levelScreen;
	public TextArea textArea;

	public static bool GameStarted = false;
	public static GameManager Instance;

	void Awake() {
		if (GameManager.Instance != this) {
			if (GameManager.Instance != null) {
				Destroy(GameManager.Instance.gameObject);
			}
		}
		GameManager.Instance = this;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(StatsRecorderInstance.gameObject);
		levelScreen.SetActive(true);
		StartCoroutine(Startup());
		motivationBar.MotivationDepleted += MotivationBar_MotivationDepleted;
		InputManager.GameEnd += InputManager_GameEnd;

	}

	void InputManager_GameEnd (bool winning)
	{
		StatsRecorderInstance.fullText = textArea.GetFullText();
		GameStarted = false;
		SceneManager.LoadScene("GameOver");
	}

	void MotivationBar_MotivationDepleted ()
	{
		StatsRecorderInstance.fullText = textArea.GetFullText();
		GameStarted = false;
		SceneManager.LoadScene("GameOver");
	}
	
	IEnumerator Startup() {
		yield return new WaitForSeconds(2.0f);
		StartGame();
	}

	void StartGame() {
		InputManagerInstance.SetupButtons();
		StatsRecorderInstance.Reset();
		levelScreen.SetActive(false);
		GameStarted = true;
	}
}
