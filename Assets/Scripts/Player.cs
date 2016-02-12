using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float currentForwardSpeed = 10f;
	public float maxForwardSpeed = 100f;
	public float acceleration = 0.01f;
	public float altitudeSpeed = 1f;

	private PlayerController controller;
	private float prevXPos = -20f;
	private int destroyed = 1;
	private Explode exploder;

	void Start() {
		controller = GetComponent<PlayerController> ();
		exploder = GetComponent<Explode> ();
	}

	void Update () {

		transform.position = new Vector2 (transform.position.x + currentForwardSpeed, transform.position.y + (altitudeSpeed * controller.moving.y));
		//rigidbody2D.velocity = new Vector2 (transform.localScale.x, 0) * currentForwardSpeed;
		//transform.position = new Vector2 ((transform.position.x + currentForwardSpeed) * Time.deltaTime, (transform.position.y + (altitudeSpeed * controller.moving.y)) * Time.deltaTime);

		Accelerate ();

		if (prevXPos >= transform.position.x){
			print ("destroyed" + destroyed);
			destroyed++;
			exploder.OnExplode();
		}

		prevXPos = transform.position.x;
	}

	void Accelerate(){
		if (currentForwardSpeed < maxForwardSpeed){
			currentForwardSpeed += acceleration;
		}
	}
}
