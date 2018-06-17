using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za kontrolę pojedynczych płytek w pokoju trzecim.
/// </summary>
public class TileController : MonoBehaviour {

    public PlayerControllerR3 player;
    public bool activated = false;
    public bool isLast = false;
    public bool isPath = false;
    public Transform doorRotate;
    public Transform path;
    public bool triggered;
    private bool cheat = false;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start () { 
        player = this.GetComponentInParent<PathController>().playerController;
        path = this.GetComponentInParent<PathController>().path;
        player.screenWidth = Screen.width / 2;
        player.screenHeight = Screen.height / 2;
    }

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void Update () {
		
	}

    /// <summary>
    /// Metoda wykrywająca wejście gracza w collider.
    /// </summary>
    /// <param name="other">Collider gracza.</param>
    private void OnTriggerEnter(Collider other)
    {
        triggered = true;
    }

    /// <summary>
    /// Metoda wykrywająca wyjście gracza w collider.
    /// </summary>
    /// <param name="other">Collider gracza.</param>
    private void OnTriggerExit(Collider other)
    {
        triggered = false;
    }

    /// <summary>
    /// Metoda wyświetlająca informacje na ekranie oraz sprawdzająca warunki gry oraz czy gracz poprawnie przeszedł przez scieżkę.
    /// </summary>
    void OnGUI()
    {
        if (triggered)
        {
            if (!isPath)
            {
                GUI.Box(new Rect(player.screenWidth - 100, player.screenHeight - 12, 300, 25), "Wrong tile! Try again from the beggining!");
                foreach (Transform child in path)
                {
                    child.GetComponentInChildren<Light>().enabled = false;
                }
            }
            else if (isPath)
            {
                this.GetComponentInChildren<Light>().enabled = true;
                this.GetComponent<TileController>().activated = true;
                if (isLast)
                {
                    foreach (Transform child in path)
                    {
                        if (child.GetComponent<TileController>().isPath)
                        {                          
                            if (child.GetComponent<TileController>().activated == false)
                            {
                                GUI.Box(new Rect(player.screenWidth - 100, player.screenHeight - 12, 200, 25), "You have cheated! Try again!");
                                cheat = true;
                            }
                        }
                    }
                    if (!cheat)
                    {
                        GUI.Box(new Rect(player.screenWidth - 100, player.screenHeight - 12, 200, 25), "Congratulations! Door are open!");
                        var rotate = Quaternion.RotateTowards(doorRotate.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 150);
                        doorRotate.rotation = rotate;
                    } else
                    {
                        foreach (Transform child in path)
                        {
                            child.GetComponentInChildren<Light>().enabled = false;
                        }
                    }
                }
            }

        }
    }
}
