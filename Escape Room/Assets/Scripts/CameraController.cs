using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public float sensitivity = 5;
	public float smooth = 2;
	public float min = -40;
	public float max = 60;

	Vector2 mouseLook;
	Vector2 smoothVector;
	GameObject player;

	void Start () {
		player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 mousePos = new Vector2 (Input.GetAxisRaw ("Mouse X"), Input.GetAxisRaw ("Mouse Y"));

		mousePos = Vector2.Scale (mousePos, new Vector2 (sensitivity*smooth, sensitivity*smooth));
		smoothVector.x = Mathf.Lerp (smoothVector.x, mousePos.x, 1 / smooth);
		smoothVector.y = Mathf.Lerp (smoothVector.y, mousePos.y, 1 / smooth);

		//smoothVector.y = Mathf.Clamp (mousePos.y, min, max); //??????

		mouseLook += smoothVector;

		transform.localRotation = Quaternion.AngleAxis (-mouseLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis (mouseLook.x, player.transform.up);
	}
}
