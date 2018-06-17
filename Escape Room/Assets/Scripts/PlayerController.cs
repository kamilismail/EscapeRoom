using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za kontrolę gracza.
/// </summary>
public class PlayerController : MonoBehaviour {

	// Use this for initialization
	public float speed = 10;
	public List<GameObject> clues;
	public bool colliderTriggered;
	public bool collected;
	public float screenWidth;
	public float screenHeight;
	public Collider c;
	public Collider keyCollider;
	public bool keyColliderTriggered;
    public bool hasKey;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start () {}

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
	void FixedUpdate () {
		float ver = Input.GetAxis ("Vertical") * speed;
		float hor = Input.GetAxis ("Horizontal") * speed;

		ver *= Time.deltaTime;
		hor *= Time.deltaTime;

		transform.Translate (hor, 0, ver);
    }

    /// <summary>
    /// Metoda wykrywająca wejście innego obiektu w nasz collider.
    /// </summary>
    /// <param name="c">Collider obiektu, w który wszedł gracz.</param>
    void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Clue")) {
			c = other;
			colliderTriggered = true;
        }
		if (other.gameObject.CompareTag ("Key")) {
			keyCollider = other;
			keyColliderTriggered = true;
		}
	}

    /// <summary>
    /// Metoda wykrywająca wyjście innego obiektu w nasz collider.
    /// </summary>
    /// <param name="c">Collider obiektu, w który wszedł gracz.</param>
    void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Clue"))
			colliderTriggered = false;
		
		if (other.gameObject.CompareTag ("Key")) {
			keyColliderTriggered = false;
		}

    }

    /// <summary>
    /// Metoda obsługująca wyświetlanie treści na ekranie. Wyświetla na ekranie komunikat "Got the key" po zebraniu klucza przez gracza.
    /// </summary>
    void OnGUI()
	{
		if (hasKey)
		{
			GUI.Box (new Rect (20, 10, 100, 25), "Got the key");

		}
	}

	
}