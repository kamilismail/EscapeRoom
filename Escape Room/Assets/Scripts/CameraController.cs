﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za obsługe kamery gracza.
/// </summary>
public class CameraController : MonoBehaviour {

	// Use this for initialization
    public float sensitivity = 5;
	public float smooth = 2;
	public float min = -45f;
	public float max = 50f;
    public Vector2 mousePos;

    Vector2 mouseLook;
	Vector2 smoothVector;
	GameObject player;


	/// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start () {
		player = this.transform.parent.gameObject;
	}
	

	/// <summary>
    /// Metoda odświeżająca się co klatkę - główny obieg.
    /// </summary>
    void FixedUpdate () {

		mousePos = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		mousePos = Vector2.Scale(mousePos, new Vector2(sensitivity * smooth, sensitivity * smooth));
		smoothVector.x = Mathf.Lerp(smoothVector.x, mousePos.x, 1 / smooth);
		smoothVector.y = Mathf.Lerp(smoothVector.y, mousePos.y, 1 / smooth);
		mouseLook += smoothVector;
		mouseLook.y = Mathf.Clamp(mouseLook.y, min, max);﻿
		transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
		player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);
    }
}
