using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuRoom2 : MonoBehaviour
{

	public bool GamePaused = false;
	public bool showClues;
	public GameObject pauseMenu;
	public AudioSource audio;
	int i;

	void Start ()
	{
	}

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

	public void Resume ()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
		GamePaused = false;
		showClues = false;
	}

	public void Pause ()
	{
		pauseMenu.SetActive (true);
		Time.timeScale = 0;
		GamePaused = true;
		showClues = false;
	}

	public void LoadMainMenu ()
	{
		Time.timeScale = 1;
		showClues = false;
		SceneManager.LoadScene (0); //load main menu scene
	}

	public void ShowClues ()
	{
		audio.Play ();
		showClues = true;
	}

	public void Back ()
	{
		audio.Stop ();
		showClues = false;
	}

	void OnGUI ()
	{
		float screenWidth = Screen.width / 2;
		float screenHeight = Screen.height / 2;
		if (showClues) {
			GUI.Box (new Rect (screenWidth - 100, screenHeight - 12, 200, 25), "Playing music");
		}
	}
}