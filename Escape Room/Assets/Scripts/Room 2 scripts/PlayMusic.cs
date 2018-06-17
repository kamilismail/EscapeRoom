using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za odgrywanie muzyki.
/// </summary>
public class PlayMusic : MonoBehaviour {

	public bool colliderTriggered;
	public bool playSong;
	public float screenWidth;
	public float screenHeight;
	public AudioSource audio;

    /// <summary>
    /// Metoda wykrywająca kliknięcie collidera.
    /// </summary>
    /// <param name="c">Collider obiektu, który wszedł w collider naszego obiektu.</param>
	void OnTriggerEnter(Collider c) {
		colliderTriggered = true;
	}

    /// <summary>
    /// Metoda wykrywająca odkniknięcie collidera.
    /// </summary>
    /// <param name="c">Collider obiektu, który wszedł w collider naszego obiektu.</param>
	void OnTriggerExit(Collider c) {
		colliderTriggered = false;
		StopSong ();
	}

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
	void Start() {}

	/// <summary>
    /// Metoda odświeżająca.
    /// </summary>
	void Update () {}

    /// <summary>
    /// Metoda puszczająca muzykę.
    /// </summary>
	void StartSong() {
		audio.Play ();
	}

    /// <summary>
    /// Metoda zatrzymująca muzykę.
    /// </summary>
	void StopSong() {
		audio.Stop ();
	}

    /// <summary>
    /// Metoda wyświetlająca treść na ekranie. Wyświetla ona na ekranie prosty komunikat "Press 'F' to play song".
    /// </summary>
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
