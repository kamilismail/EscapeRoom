using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public bool GamePaused = false;
	public bool showClues;
	public GameObject pauseMenu;
	private List<GameObject> list;
	private Renderer rend;
	int i;

	void Start ()
	{
		list = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ().clues;
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
		showClues = true;
	}

	public void Back ()
	{
		showClues = false;
	}

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