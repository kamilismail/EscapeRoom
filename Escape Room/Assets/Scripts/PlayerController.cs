using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float speed = 10;
	public List<GameObject> clues;
	public bool colliderTriggered;
	public bool collected;
	public float screenWidth;
	public float screenHeight;
	public Collider c;
    public bool hasKey;

	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		float ver = Input.GetAxis ("Vertical") * speed;
		float hor = Input.GetAxis ("Horizontal") * speed;

		ver *= Time.deltaTime;
		hor *= Time.deltaTime;

		transform.Translate (hor, 0, ver);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Clue")) {
			c = other;
			colliderTriggered = true;
        }
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Clue"))
			colliderTriggered = false;

    }

	
}