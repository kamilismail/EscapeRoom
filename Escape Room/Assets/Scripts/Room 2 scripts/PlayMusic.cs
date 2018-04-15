using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMusic : MonoBehaviour {

	public bool colliderTriggered;
	public bool playSong;
	public float screenWidth;
	public float screenHeight;
	public AudioSource audio;

	void OnTriggerEnter(Collider c) {
		colliderTriggered = true;
	}

	void OnTriggerExit(Collider c) {
		colliderTriggered = false;
		StopSong ();
	}

	void Start() {
	}

	// Update is called once per frame
	void Update () {
	}

	void StartSong() {
		audio.Play ();
	}

	void StopSong() {
		audio.Stop ();
	}

	void OnGUI() {

		screenWidth = Screen.width / 2;
		screenHeight = Screen.height / 2;
		if (colliderTriggered) {
			GUI.Box (new Rect(screenWidth - 100, screenHeight - 12, 200, 25), "Press 'F' to play song");

			if (Input.GetKeyDown (KeyCode.F)) {
				StartSong ();
				colliderTriggered = false;
			}
		}
	}
}
