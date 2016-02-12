using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {

	public Bits bits;
	public int totalBits = 5;

	private int exploded = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D target){
		if (target.gameObject.tag == "Deadly") {
			OnExplode();
		}
	}

	void OnCollisionEnter2D( Collision2D target){
		if (target.gameObject.tag == "Deadly") {
			print ("Exploded " + exploded);
			exploded++;
			OnExplode();
		}
	}

	public void OnExplode() {
		//destroys player
		Destroy (gameObject);

		var t = transform;

		//creates body parts when player explodes
		for (int i = 0; i < totalBits; i++) {
			//parts start outside of the player's area
			t.TransformPoint (0, -100, 0);
			//clones the body parts (what gets cloned, position of clone, 0 rotation) as type Bodypart
			Bits clone = Instantiate (bits, t.position, Quaternion.identity) as Bits;
			//applies force to the objects in random direction left or right
			clone.GetComponent<Rigidbody2D>().AddForce (Vector3.right * Random.Range (-50, 50));
			//applies force to the object random intensity upward
			clone.GetComponent<Rigidbody2D>().AddForce (Vector3.up * Random.Range (100, 400));
		}

		GameObject go = new GameObject ("ClickToContinue");
		ClickToContinue script = go.AddComponent<ClickToContinue> ();
		script.scene = Application.loadedLevelName;

		go.AddComponent<DisplayRestartText> ();
	}
}
