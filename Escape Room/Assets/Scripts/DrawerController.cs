using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Klasa odpowiedzialna za obsługe szuflady w biurku.
/// </summary>
[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class DrawerController : MonoBehaviour {

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
    public PlayerController player;

    /// <summary>
    /// Metoda inicjalizująca.
    /// </summary>
    void Start()
    {
        m_State = eInteractiveState.Inactive;
        m_AnimNames = new string[anim.GetClipCount()];
        int index = 0;
        foreach(AnimationState anim in anim)
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

}
