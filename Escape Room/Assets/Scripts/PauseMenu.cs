using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa obsługująca menu pauzy w pokoju pierwszym.
/// </summary>
public class PauseMenu : MonoBehaviour
{

	public bool GamePaused = false;
	public bool showClues;
	public GameObject pauseMenu;
	private List<GameObject> list;
	private Renderer rend;
	int i;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
	void Start ()
	{
		list = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().clues;
	}

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && !GamePaused) {
			if (GamePaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}

    /// <summary>
    /// Metoda, która wznawia grę i chowa menu pauzy.
    /// </summary>
	public void Resume ()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
		GamePaused = false;
		showClues = false;
	}

    /// <summary>
    /// Metoda, która przerywa grę i wyświetla menu pauzy.
    /// </summary>
	public void Pause ()
	{
		pauseMenu.SetActive (true);
		Time.timeScale = 0;
		GamePaused = true;
		showClues = false;
	}

    /// <summary>
    /// Metoda, która ładuje główne menu gry.
    /// </summary>
	public void LoadMainMenu ()
	{
		Time.timeScale = 1;
		showClues = false;
		SceneManager.LoadScene (0); //load main menu scene
	}

    /// <summary>
    /// Metoda, która pozwala uruchomić pokazanie podpowiedzi.
    /// </summary>
	public void ShowClues ()
	{
		showClues = true;
	}

    /// <summary>
    /// Metoda, która uniemożliwia uruchomić pokazanie podpowiedzi.
    /// </summary>
	public void Back ()
	{
		showClues = false;
	}

    /// <summary>
    /// Metoda wyświetlająca treść na ekranie. Wyświetla ona wskazówki, które zebrał gracz.
    /// </summary>
	void OnGUI ()
	{
		float screenWidth = Screen.width / 2;
		float screenHeight = Screen.height / 2;
		if (showClues) {
			if (list.Count > 0) {

				GUI.Box (new Rect (20, 240, 200, 25), "You found "+list.Count+" clues");

				if (GUI.Button (new Rect (20, 10, 100, 100), "Next")) {
					if (i < list.Count - 1)
						i++;
				}
				if (GUI.Button (new Rect (20, 120, 100, 100), "Previous")) {
					if (i > 0)
						i--;
				}
				rend = list [i].GetComponent<Renderer> ();
				GUI.DrawTexture (new Rect (screenWidth - 150, screenHeight - 200, 300, 500), rend.material.mainTexture);
			} else {
				GUI.Box (new Rect (screenWidth - 100, screenHeight - 12, 200, 25), "Find some clues first!");
			}
		}
	}
}