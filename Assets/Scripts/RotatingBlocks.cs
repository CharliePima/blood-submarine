﻿using UnityEngine;
using System.Collections;

public class RotatingBlocks : MonoBehaviour {

	public float rotationSpeed = 0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, rotationSpeed);
	}
}
