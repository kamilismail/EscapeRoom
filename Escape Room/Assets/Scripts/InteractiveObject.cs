using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class InteractiveObject : MonoBehaviour
{

    public enum eInteractiveState
    {
        Active,     //Open
        Inactive,   //Close
    }

    private eInteractiveState m_State;
    private string[] m_AnimNames;
    public Animation anim;
    private Renderer render;
    public Transform other;
    public PlayerController player;
    public GameObject clue4;


    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        m_State = eInteractiveState.Inactive;
        m_AnimNames = new string[anim.GetClipCount()];
        int index = 0;
        foreach (AnimationState anim in anim)
        {
            m_AnimNames[index] = anim.name;
            index++;
        }
    }

    public void TriggerInteraction()
    {

        if (!anim.isPlaying)
        {
            switch (m_State)
            {
                case eInteractiveState.Active:
                    anim.Play(m_AnimNames[1]);
                    m_State = eInteractiveState.Inactive;
                    break;
                case eInteractiveState.Inactive:
                    anim.Play(m_AnimNames[0]);
                    m_State = eInteractiveState.Active;
                    break;
                default:
                    break;
            }
        }
    }

    void OnGUI()
    {
        player.screenWidth = Screen.width / 2;
        player.screenHeight = Screen.height / 2;
        if (render.isVisible && Vector3.Distance(other.position, transform.position) < 1.5f)
        {
            if (m_State == eInteractiveState.Active && !clue4.activeSelf)
                GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "Press 'F' to close a drawer");
            else if (m_State == eInteractiveState.Inactive)
                if (player.hasKey)
                    GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "Press 'F' to open a drawer");
                else
                {
                    GUI.Box(new Rect(player.screenWidth - 125, player.screenHeight - 12, 250, 25), "You need the key to open this drawer!");
                    return;
                }


            if (Input.GetKeyDown(KeyCode.F))
            {
				player.hasKey = false;
                if(!clue4.activeSelf)
                    TriggerInteraction();
                if (m_State == eInteractiveState.Active)
                    clue4.SetActive(true);
                else
                    clue4.SetActive(false);
            }
        }
    }


}
