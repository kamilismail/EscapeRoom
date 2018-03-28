using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public List<GameObject> list;
	private bool showClues;
	// Use this for initialization
	void Start () {
		list = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController>().clues;
	}
	
	// Update is called once per frame
	void Update () {
		showClues = true;
	}

	void OnGUI () {
		if (showClues) {
			int x = list.Count;
			for (int i = 0; i < list.Count;) {
				if (Input.GetKeyDown (KeyCode.RightArrow) && i < x)
					i++;
				if (Input.GetKeyDown (KeyCode.LeftArrow) && i > 0)
					i--;
				
				GUI.DrawTexture (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 400, 500, 800), list[i].GetComponent<Texture>());
			
			}
		}
	}
}
