using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animation))]
public class DrawerController : MonoBehaviour {
    // public GameObject OpenPanel = null;
    //   private bool isInsideTrigger = false;
    //   public Animator animator;
    //   public string openText = "Press 'F' to open a Drawer";
    //   public string closeText = "Press 'F' to close a Drawer";
    //   private bool isOpened = false;


    //   // Use this for initialization
    //   void Start () {

    //}

    //   void OnTriggerEnter(Collider other)
    //   {
    //       if (other.tag == "Player")
    //       {
    //           isInsideTrigger = true;
    //           //OpenPanel.SetActive(true);
    //       }
    //   }

    //   void OnTriggerExit(Collider other)
    //   {
    //       if (other.tag == "Player")
    //       {
    //           isInsideTrigger = false;
    //           //OpenPanel.SetActive(false);
    //       }
    //   }

    //  /* private bool IsOpenPanelActive
    //   {
    //       get
    //       {
    //           return OpenPanel.activeInHierarchy;
    //       }
    //   }*/

    //   // Update is called once per frame
    //   void Update()
    //   {
    //       if(isInsideTrigger)
    //       {
    //           if(Input.GetKeyDown(KeyCode.F))
    //           {
    //               isOpened = !isOpened;
    //               //OpenPanel.SetActive(false);
    //               animator.SetBool("open", true);
    //           }
    //       }
    //   }

    public enum eInteractiveState
    {
        Active,     //Open
        Inactive,   //Close
    }

    private eInteractiveState m_State;
    private string[] m_AnimNames;
    public Animation anim;


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
