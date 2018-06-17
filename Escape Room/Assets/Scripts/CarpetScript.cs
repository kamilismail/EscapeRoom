using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Klasa odpowiedzialna za ruch dywanu
/// </summary>
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
	public GameObject key;
    private Renderer render;
    public Transform other;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
    }

    /// <summary>
    /// Metoda wykrywająca wejście innego obiektu w nasz collider.
    /// </summary>
    /// <param name="c">Collider obiektu, który wszedł w collider naszego obiektu.</param>
    void OnTriggerEnter(Collider c) {
		colliderTriggered = true;
	}

    /// <summary>
    /// Metoda wykrywająca wyjście innego obiektu w nasz collider.
    /// </summary>
    /// <param name="c">Collider obiektu, który wszedł w collider naszego obiektu.</param>
	void OnTriggerExit(Collider c) {
		colliderTriggered = false;
	}

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void Update () {   

        if (carpetMoved && !moveDone) {
			float step = speed * Time.deltaTime;
			carpet.transform.position = Vector3.MoveTowards (carpet.transform.position, vec, step);
			clue1.gameObject.SetActive (true);
			key.gameObject.SetActive (true);
			if (carpet.transform.position.Equals(vec))
				moveDone = true;
		}
	}

    /// <summary>
    /// Metoda obsługująca wyświetlanie treści na ekranie. Wyświetla na ekranie komunikat "Press 'F' to move the carpet" po podejściu gracza do zagadki.
    /// </summary>
	void OnGUI() {
		screenWidth = Screen.width / 2;
		screenHeight = Screen.height / 2;
		if (!carpetMoved && render.isVisible && Vector3.Distance(other.position, transform.position) < 1.5f) {
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
