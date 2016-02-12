using UnityEngine;
using System.Collections;

public class MoveForward : MonoBehaviour {

	public float speed = .5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//moves creature along the x axis (or y axis, if not zero), multiplied by the speed
		GetComponent<Rigidbody2D>().velocity = new Vector2 (transform.localScale.x, 0) * speed;
	}
}
