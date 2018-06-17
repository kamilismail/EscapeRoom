using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za kontrolę ścieżki w pokoju 3.
/// </summary>
public class PathController : MonoBehaviour
{

    public Transform path;
    public PlayerControllerR3 playerController;
    private bool start = true;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start()
    {
        foreach (Transform child in path)
        {
            child.GetComponentInChildren<Light>().enabled = false;
        }
        Coroutine();
        
    }

    /// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void FixedUpdate()
    {

    }

    /// <summary>
    /// Metoda pomocnicza pozwalająca łtwo odpalać coroutine.
    /// </summary>
    public void Coroutine()
    {
        StartCoroutine(showPath());
    }

    /// <summary>
    /// Metoda działająca w coroutine. Wyświetla ona ścieżkę do przejscia dla gracza w pokoju trzecim.
    /// </summary>
    /// <returns></returns>
    IEnumerator showPath()
    {
            for (int i = 0; i < 13; i++)
            {
                foreach (Transform child in path)
                {

                    if (child.name.ToString().Equals(i.ToString()))
                    {
                        if (child.GetComponentInChildren<Light>().enabled == false)
                        {                         
                            child.GetComponentInChildren<Light>().enabled = true;
                            yield return new WaitForSeconds(0.5f);
                            child.GetComponentInChildren<Light>().enabled = false;
                            break;
                        }
                    }
                }
            }
       
    }
}
