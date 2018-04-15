using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeypadController : MonoBehaviour {

	public string password;
	public string input;
	public bool colliderTriggered;
	public bool screenOn;
	public bool openDoor;
	public bool correctPassword;
	public bool enterTriggered;
	public Transform doorRotate;
	public float screenWidth;
	public float screenHeight;

	void OnTriggerEnter(Collider c) {
		colliderTriggered = true;
	}

	void OnTriggerExit(Collider c) {
		colliderTriggered = false;
		screenOn = false;
		enterTriggered = false;
		correctPassword = false;
		input = "";
	}
		
	// Update is called once per frame
	void Update () {
		if (input == password && enterTriggered) {
			openDoor = true;
			screenOn = false;
			colliderTriggered = false;
			Time.timeScale = 1;
			correctPassword = true;
		} else if (input != password && enterTriggered) {
			screenOn = false;
			enterTriggered = false;
			colliderTriggered = false;
			input = "";
			Time.timeScale = 1;
		}
		if (openDoor) {
			var rotate = Quaternion.RotateTowards(doorRotate.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 150);
			doorRotate.rotation = rotate;
		}
	}

	void OnGUI() {

		screenWidth = Screen.width / 2;
		screenHeight = Screen.height / 2;
		if (!openDoor && colliderTriggered) {
			GUI.Box (new Rect(screenWidth - 100, screenHeight - 12, 200, 25), "Press 'F' to type a code");

			if (Input.GetKeyDown (KeyCode.F)) {
				screenOn = true;
				colliderTriggered = false;
			}
		}

		if (correctPassword) {
			GUI.Box (new Rect(screenWidth - 75, screenHeight - 12, 150, 25), "Success!");
			colliderTriggered = false;
		}


		if (screenOn) {
			Time.timeScale = 0;
			float width = screenWidth - 160;
			float height = screenHeight - 160;
			GUI.Box (new Rect(width, height, 320, 455), "");
			GUI.Box (new Rect(width + 5, height + 5, 310, 25), input);

			if (GUI.Button (new Rect (width + 5, height + 35, 100, 100), "1") )//|| Input.GetKeyDown (KeyCode.Alpha1))
				input += "1";
			if (GUI.Button (new Rect (width + 110, height + 35, 100, 100), "2") )//|| Input.GetKeyDown (KeyCode.Alpha2))
				input += "2";
			if (GUI.Button (new Rect (width + 215, height + 35, 100, 100), "3") )//|| Input.GetKeyDown (KeyCode.Alpha3))
				input += "3";
			if (GUI.Button (new Rect (width + 5, height + 140, 100, 100), "4") )//|| Input.GetKeyDown (KeyCode.Alpha4))
				input += "4";
			if (GUI.Button (new Rect (width + 110, height + 140, 100, 100), "5") )//|| Input.GetKeyDown (KeyCode.Alpha5))
				input += "5";
			if (GUI.Button (new Rect (width + 215, height + 140, 100, 100), "6") )//|| Input.GetKeyDown (KeyCode.Alpha6))
				input += "6";
			if (GUI.Button (new Rect (width + 5, height + 245, 100, 100), "7") )//|| Input.GetKeyDown (KeyCode.Alpha7))
				input += "7";
			if (GUI.Button (new Rect (width + 110, height + 245, 100, 100), "8") )//|| Input.GetKeyDown (KeyCode.Alpha8))
				input += "8";
			if (GUI.Button (new Rect (width + 215, height + 245, 100, 100), "9") )//|| Input.GetKeyDown (KeyCode.Alpha9))
				input += "9";
			if (GUI.Button (new Rect (width + 5, height + 350, 100, 100), "0") )//|| Input.GetKeyDown (KeyCode.Alpha0))
				input += "0";
			if (GUI.Button (new Rect (width + 110, height + 350, 100, 100), "Enter") || Input.GetKeyDown (KeyCode.Return))
				enterTriggered = true;
			if (GUI.Button (new Rect (width + 215, height + 350, 100, 100), "Delete") || Input.GetKeyDown (KeyCode.Delete) || Input.GetKeyDown (KeyCode.Backspace))
				input = "";
			if (GUI.Button (new Rect (10, 10, 100, 100), "Back")) {
				colliderTriggered = false;
				screenOn = false;
				enterTriggered = false;
				input = "";
				Time.timeScale = 1;
			}
		}


	}
}
