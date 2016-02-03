using UnityEngine;
using System.Collections;

public class Test_TextDatabase : MonoBehaviour {

	public TextDB tdb;

	private string[] testum;

	// Use this for initialization
	void Start () {
		testum = tdb.ServeText(0);
		Debug.Assert(testum[0] == "There");
		Debug.Assert(testum[1] == "was");
		Debug.Assert(testum[2] == "no");
		Debug.Assert(testum[3] == "possibility");
		Debug.Log("TEST COMPLETE");
	}
}
