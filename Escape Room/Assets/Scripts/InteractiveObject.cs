using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za obługę obiektów interaktywnych - głównie szuflad.
/// </summary>
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class InteractiveObject : MonoBehaviour
{

    /// <summary>
    /// Tym wyliczeniowy opisujący stan szuflady (otwarta, zamknięta).
    /// </summary>
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

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
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

    /// <summary>
    /// Metoda obsługująca działanie z triggerem. Odpowiada ona za uruchamianie animacji otwarcia/zamknięcia szuflady.
    /// </summary>
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

    /// <summary>
    /// Metoda obsługująca wyświetlanie treści na ekranie.
    /// Wyświetla odpowiednie komunikaty po podejściu gracza do szuflady:
    /// "Press 'F' to close a drawer",
    /// "Press 'F' to open a drawer" lub
    /// "You need the key to open this drawer!".
    /// </summary>
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
