using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour {

	private bool isDeactivated;
	public PlayerController player;
	public Transform other;

	void Start () {
		isDeactivated = false;
		player.screenWidth = Screen.width / 2;
		player.screenHeight = Screen.height / 2;
	}

	// Update is called once per frame
	void Update () {
		if (isDeactivated == true)
			player.keyCollider.gameObject.SetActive (false);
	}

	void OnGUI()
	{
		if (player.keyColliderTriggered && Vector3.Distance(other.position, transform.position) < 10.0f)
		{
			GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "Press 'F' to get key");

			if (Input.GetKeyDown(KeyCode.F))
			{            
				player.keyColliderTriggered = false;
				player.hasKey = true;
				isDeactivated = true;
			}
		}
	}
}
