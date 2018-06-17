using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Klasa odpowiedzialna za zmianę sceny na następną.
/// </summary>
public class MoveTo2Room : MonoBehaviour {
	
    /// <summary>
    /// Metoda, która po wejściu gracza w collider zmienia scenę na następną w builderze.
    /// </summary>
    /// <param name="c">Collider gracza.</param>
	void OnTriggerEnter(Collider c) {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); //load next room
	}
}
