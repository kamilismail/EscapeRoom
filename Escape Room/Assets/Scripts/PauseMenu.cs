using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

	public bool GamePaused = false;
	public GameObject pauseMenu;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (GamePaused) {
				Resume ();
			} else {
				Pause();
		}
	}
}

	public void Resume() {
		pauseMenu.SetActive (false);
		Time.timeScale = 1;
		GamePaused = false;
	}

	public void Pause() {
		pauseMenu.SetActive (true);
		Time.timeScale = 0;
		GamePaused = true;
	}

	public void LoadMainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene (0); //load main menu scene
	}

}