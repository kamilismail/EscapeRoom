using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za obsługe wskazówek.
/// </summary>
public class ClueController : MonoBehaviour {

    private Renderer render;
    private bool isDeactivated;
    public Transform other;
    public PlayerController player;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start () {
        render = gameObject.GetComponent<Renderer>();
        isDeactivated = false;
		player.screenWidth = Screen.width / 2;
		player.screenHeight = Screen.height / 2;
    }

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void Update () {
        if(isDeactivated == true)
            player.c.gameObject.SetActive(false);
    }

    /// <summary>
    /// Metoda obsługująca wyświetlanie treści na ekranie. Wyświetla na ekranie komunikat "Press 'F' to get clue" po podejściu gracza do zagadki.
    /// </summary>
    void OnGUI()
    {
        if (!player.collected && player.colliderTriggered && render.isVisible && Vector3.Distance(other.position, transform.position) < 1.5f)
        {
            GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "Press 'F' to get clue");

            if (Input.GetKeyDown(KeyCode.F))
            {
                
                player.clues.Add(player.c.gameObject);              
                player.colliderTriggered = false;
                isDeactivated = true;
            }
        }
    }

}

