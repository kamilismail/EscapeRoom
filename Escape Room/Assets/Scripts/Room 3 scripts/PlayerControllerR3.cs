using Boo.Lang;
using UnityEngine;

//Klasa odpowiedzialna za kontrolę gracza w pokoju trzecim.
public class PlayerControllerR3 : MonoBehaviour {

	// Use this for initialization
	public float speed = 10;
    public GameObject hiddenBook;
	public bool tileColliderTriggered;
	public bool collected;
	public float screenWidth;
	public float screenHeight;
	public Collider tileCollider;
	public Collider bookCollider;
	public bool bookColliderTriggered;
    public bool congrats;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start () {
	}

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
		if (other.gameObject.CompareTag ("Book")) {
            bookCollider = other;
            bookColliderTriggered = true;
        }
		if (other.gameObject.CompareTag ("Tile")) {
            tileCollider = other;
            tileColliderTriggered = true;
		}
	}

    /// <summary>
    /// Metoda wykrywająca wejście innego obiektu w nasz collider.
    /// </summary>
    /// <param name="c">Collider obiektu, w który wszedł gracz.</param>
	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Tile"))
			tileColliderTriggered = false;
		
		if (other.gameObject.CompareTag ("Book")) {
			bookColliderTriggered = false;
		}

    }

    /// <summary>
    /// Metoda obsługująca wyświetlanie treści na ekranie. Wyświetla na ekranie komunikat "Door open!" po poprawnym przejściu przez ścieżkę.
    /// </summary>
	void OnGUI()
	{
		if (congrats)
		{
			GUI.Box (new Rect (20, 10, 100, 25), "Door open!");
		}
	}
	
}