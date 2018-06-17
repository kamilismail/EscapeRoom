using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa obsługująca menu pauzy w pokoju drugim.
/// </summary>
public class PauseMenuRoom2 : MonoBehaviour
{

	public bool GamePaused = false;
	public bool showClues;
	public GameObject pauseMenu;
	public AudioSource audio;
	int i;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start () {}

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
		audio.Play ();
		showClues = true;
	}

    /// <summary>
    /// Metoda, która uniemożliwia uruchomić pokazanie podpowiedzi.
    /// </summary>
    public void Back ()
	{
		audio.Stop ();
		showClues = false;
	}

    /// <summary>
    /// Metoda wyświetlająca treść na ekranie. Informuje ona o poprawnym odegraniu muzyki.
    /// </summary>
    void OnGUI ()
	{
		float screenWidth = Screen.width / 2;
		float screenHeight = Screen.height / 2;
		if (showClues) {
			GUI.Box (new Rect (screenWidth - 100, screenHeight - 12, 200, 25), "Playing music");
		}
	}
}