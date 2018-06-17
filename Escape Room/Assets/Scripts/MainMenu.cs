using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiedzialna za zarządzanie scenę menu.
/// </summary>
public class MainMenu : MonoBehaviour {

    /// <summary>
    /// Metoda uruchamiająca grę - pierwszy pokój.
    /// </summary>
	public void StartGame() {
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Metoda odpowiedzialna za zamknięcie applikacji.
    /// </summary>
	public void ExitGame() {
		Application.Quit ();
	}
}