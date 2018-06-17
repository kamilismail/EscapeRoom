using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa obsługująca menu pauzy w pokoju trzecim.
/// </summary>
public class PauseMenuRoom3 : MonoBehaviour
{

    public bool GamePaused = false;
    public bool showClues;
    public GameObject pauseMenu;
    public PathController pathCtrl;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start()
    {
    }

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GamePaused)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /// <summary>
    /// Metoda, która wznawia grę i chowa menu pauzy.
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        GamePaused = false;
        showClues = false;
    }

    /// <summary>
    /// Metoda, która przerywa grę i wyświetla menu pauzy.
    /// </summary>
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        GamePaused = true;
        showClues = false;
    }

    /// <summary>
    /// Metoda, która ładuje główne menu gry.
    /// </summary>
    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        showClues = false;
        SceneManager.LoadScene(0); //load main menu scene
    }

    /// <summary>
    /// Metoda, która pozwala uruchomić pokazanie podpowiedzi.
    /// </summary>
    public void ShowClues()
    {
        showClues = true;
    }

    /// <summary>
    /// Metoda która pozwala w tym przypadku odpalić coroutine, czyli wyświetlić podpowiedź dla gracza w pokoju trzecim - pokazać mu scieżkę.
    /// </summary>
    void OnGUI()
    {
        float screenWidth = Screen.width / 2;
        float screenHeight = Screen.height / 2;
        if (showClues)
        {            
            //GUI.Box(new Rect(screenWidth - 100, screenHeight - 12, 200, 25), "Look");
            pathCtrl.Coroutine();
            showClues = false;
        }
    }
}