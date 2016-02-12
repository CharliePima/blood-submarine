using UnityEngine;
using System.Collections;

public class BounceOffWalls : MonoBehaviour {

	public float speed = 0.005f;
	public bool goUp = true;

	// Use this for initialization
	void Start () {
	
	}

	void OnCollisionEnter2D (Collision2D target){
		if (goUp)
		{
			goUp = false;
		}
		else
		{
			goUp = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (goUp)
		{
			transform.position = new Vector2 (transform.position.x, transform.position.y + speed);
		}
		else
		{
			transform.position = new Vector2 (transform.position.x, transform.position.y - speed);
		}
	}
}
