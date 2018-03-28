using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveTo2Room : MonoBehaviour {
	
	void OnTriggerEnter(Collider c) {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1); //load next room
	}
}
