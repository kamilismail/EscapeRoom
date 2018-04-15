using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class DrawerController : MonoBehaviour {

    public enum eInteractiveState
    {
        Active,     //Open
        Inactive,   //Close
    }

    private eInteractiveState m_State;
    private string[] m_AnimNames;
    public Animation anim;
    public PlayerController player;

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
