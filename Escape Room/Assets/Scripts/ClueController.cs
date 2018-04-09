using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueController : MonoBehaviour {

    private Renderer render;
    private bool isDeactivated;
    public Transform other;
    public PlayerController player;

    // Use this for initialization
    void Start () {
        render = gameObject.GetComponent<Renderer>();
        isDeactivated = false;
    }
	
	// Update is called once per frame
	void Update () {
        if(isDeactivated == true)
            player.c.gameObject.SetActive(false);
    }

    void OnGUI()
    {
        player.screenWidth = Screen.width / 2;
        player.screenHeight = Screen.height / 2;
        if (!player.collected && player.colliderTriggered && render.isVisible && Vector3.Distance(other.position, transform.position) < 1.5f)
        {
            GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "Press 'F' to get clue");

            if (Input.GetKeyDown(KeyCode.F))
            {
                
                player.clues.Add(player.c.gameObject);              
                player.colliderTriggered = false;
                isDeactivated = true;
            }
        }
    }

}

