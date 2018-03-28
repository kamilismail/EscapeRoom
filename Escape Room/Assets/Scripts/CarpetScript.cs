using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetScript : MonoBehaviour {


	public bool colliderTriggered;
	public bool carpetMoved;
	public float screenWidth;
	public float screenHeight;
	public bool moveDone;
	public GameObject carpet;
	public float speed = 2;
	Vector3 vec;
	public GameObject clue1;

	void OnTriggerEnter(Collider c) {
		colliderTriggered = true;
	}

	void OnTriggerExit(Collider c) {
		colliderTriggered = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (carpetMoved && !moveDone) {
			float step = speed * Time.deltaTime;
			carpet.transform.position = Vector3.MoveTowards (carpet.transform.position, vec, step);
			clue1.gameObject.SetActive (true);
			if (carpet.transform.position.Equals(vec))
				moveDone = true;
		}
	}

	void OnGUI() {
		screenWidth = Screen.width / 2;
		screenHeight = Screen.height / 2;
		if (!carpetMoved && colliderTriggered) {
			GUI.Box (new Rect (screenWidth - 125, screenHeight - 12, 250, 25), "Press 'F' to move the carpet");

			if (Input.GetKeyDown (KeyCode.F)) {
				vec = carpet.transform.position;
				vec.z += 1.65f;
				carpetMoved = true;
				colliderTriggered = false;
			}
		}
	}
}
