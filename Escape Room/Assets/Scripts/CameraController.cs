using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	// Use this for initialization
	public float sensitivity = 5;
	public float smooth = 2;
	public float min = -40;
	public float max = 60;
    public Vector2 mousePos;
    public GameObject camera;


    Vector2 mouseLook;
	Vector2 smoothVector;
	GameObject player;

	void Start () {
		player = this.transform.parent.gameObject;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (transform.rotation.eulerAngles.x >= 310 && transform.rotation.eulerAngles.x <= 360)
        {
            //max = 1;
            ////transform.Rotate(0, 0, 0);
            //camera.transform.rotation.eulerAngles.Set(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            mousePos = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mousePos = Vector2.Scale(mousePos, new Vector2(sensitivity * smooth, sensitivity * smooth));
            smoothVector.x = Mathf.Lerp(smoothVector.x, mousePos.x, 1 / smooth);
            smoothVector.y = Mathf.Lerp(smoothVector.y, mousePos.y, 1 / smooth);
            //smoothVector.y = Mathf.Clamp (mousePos.y, min, max); //??????

            mouseLook += smoothVector;

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

            if (transform.rotation.eulerAngles.x < 310 && transform.rotation.eulerAngles.x > 50)
            {
                transform.rotation = Quaternion.Euler(311, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
                
            }

        }
        else if (transform.rotation.eulerAngles.x <= 45 && transform.rotation.eulerAngles.x >= 0)
        {
            //transform.Rotate(max, 0, 0);
            //transform.rotation.eulerAngles.Set(44.9f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            mousePos = new Vector3(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mousePos = Vector2.Scale(mousePos, new Vector2(sensitivity * smooth, sensitivity * smooth));
            smoothVector.x = Mathf.Lerp(smoothVector.x, mousePos.x, 1 / smooth);
            smoothVector.y = Mathf.Lerp(smoothVector.y, mousePos.y, 1 / smooth);
            //smoothVector.y = Mathf.Clamp (mousePos.y, min, max); //??????

            mouseLook += smoothVector;

            transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
            player.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, player.transform.up);

            if (transform.rotation.eulerAngles.x > 45 && transform.rotation.eulerAngles.x < 300)
            {
                transform.rotation = Quaternion.Euler(44, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

            }
        }
        min = transform.rotation.eulerAngles.x;
        
            //transform.rotation.eulerAngles.Set(310, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);


    }
}
