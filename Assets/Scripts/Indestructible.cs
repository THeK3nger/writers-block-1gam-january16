﻿using UnityEngine;
using System.Collections;

public class Indestructible : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject.DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
