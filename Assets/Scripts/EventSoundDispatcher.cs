using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventSoundDispatcher : MonoBehaviour {

	public List<AudioClip> WordRightSounds;
	public AudioClip NewLineSound;

	// Use this for initialization
	void Start () {
		InputManager.WordFired += InputManager_WordFired;
	}

	void InputManager_WordFired (string word, bool isRight)
	{
		if (isRight)
		{
		    AudioSource.PlayClipAtPoint(
		        word[word.Length - 1] == '\n' ? NewLineSound : RandomSound(),
		        Camera.main.transform.position);
		}
	}

    private AudioClip RandomSound()
    {
        return WordRightSounds[Random.Range(0, WordRightSounds.Count)];
    }
	
	void OnDisable() {
		InputManager.WordFired -= InputManager_WordFired;
	}
}
