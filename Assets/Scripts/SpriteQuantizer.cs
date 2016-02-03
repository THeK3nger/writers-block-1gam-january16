using UnityEngine;
using System.Collections;

public class SpriteQuantizer : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		var old_pos = transform.position;
		var newX = Mathf.Ceil(400*old_pos.x)/400.0f;
		var newY = Mathf.Ceil(400*old_pos.y)/400.0f;
		transform.position = new Vector2(newX, newY);
	}
}
