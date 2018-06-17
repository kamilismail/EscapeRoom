using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za obsługe klucza.
/// </summary>
public class KeyController : MonoBehaviour {

	private bool isDeactivated;
	public PlayerController player;
	public Transform other;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
	void Start () {
		isDeactivated = false;
		player.screenWidth = Screen.width / 2;
		player.screenHeight = Screen.height / 2;
	}

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void Update () {
		if (isDeactivated == true)
			player.keyCollider.gameObject.SetActive (false);
	}

    /// <summary>
    /// Metoda obsługująca wyświetlanie treści na ekranie.
    /// Wyświetla "Press 'F' to get key" w przypadku podejścia gracza do klucza.
    /// </summary>
    void OnGUI()
	{
		if (player.keyColliderTriggered && Vector3.Distance(other.position, transform.position) < 10.0f)
		{
			GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "Press 'F' to get key");

			if (Input.GetKeyDown(KeyCode.F))
			{            
				player.keyColliderTriggered = false;
				player.hasKey = true;
				isDeactivated = true;
			}
		}
	}
}
