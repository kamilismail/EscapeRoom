using Boo.Lang;
using UnityEngine;

public class PlayerControllerR3 : MonoBehaviour {

	// Use this for initialization
	public float speed = 10;
    public GameObject hiddenBook;
	public bool tileColliderTriggered;
	public bool collected;
	public float screenWidth;
	public float screenHeight;
	public Collider tileCollider;
	public Collider bookCollider;
	public bool bookColliderTriggered;
    public bool congrats;

	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		float ver = Input.GetAxis ("Vertical") * speed;
		float hor = Input.GetAxis ("Horizontal") * speed;

		ver *= Time.deltaTime;
		hor *= Time.deltaTime;

		transform.Translate (hor, 0, ver);
    }

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Book")) {
            bookCollider = other;
            bookColliderTriggered = true;
        }
		if (other.gameObject.CompareTag ("Tile")) {
            tileCollider = other;
            tileColliderTriggered = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Tile"))
			tileColliderTriggered = false;
		
		if (other.gameObject.CompareTag ("Book")) {
			bookColliderTriggered = false;
		}

    }

	void OnGUI()
	{
		if (congrats)
		{
			GUI.Box (new Rect (20, 10, 100, 25), "Door open!");
		}
	}
	
}