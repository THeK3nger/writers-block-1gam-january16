using UnityEngine;
using System.Collections;

public class BaseCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		const float UnitsPerPixel = 1f / 100f;
		const float PixelSize = 4.0f;
		//float PixelsPerUnit = 100f / 1f; // yeah, yeah, 100
		Debug.Log("Suggested Camera Size: " + ((Screen.height / 2f * UnitsPerPixel)/PixelSize));
	}

}
