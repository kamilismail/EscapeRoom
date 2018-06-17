using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathController : MonoBehaviour
{

    public Transform path;
    public PlayerControllerR3 playerController;
    private bool start = true;


    // Use this for initialization
    void Start()
    {
        foreach (Transform child in path)
        {
            child.GetComponentInChildren<Light>().enabled = false;
        }
        Coroutine();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    public void Coroutine()
    {
        StartCoroutine(showPath());
    }

    IEnumerator showPath()
    {
        //if (start)
        //{
        //    for (int k = 0; k < 4; k++)
        //    {
        //        for (int i = 0; i < 13; i++)
        //        {
        //            foreach (Transform child in path)
        //            {

        //                if (child.name.ToString().Equals(i.ToString()))
        //                {
        //                    //Debug.Log(child.name.ToString() + " === " + i.ToString() + " : " + child.name.ToString().Equals(i.ToString()));
        //                    child.GetComponentInChildren<Light>().enabled = true;
        //                    yield return new WaitForSeconds(1);
        //                    child.GetComponentInChildren<Light>().enabled = false;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    start = false;
        //}
        //else
        //{
            for (int i = 0; i < 13; i++)
            {
                foreach (Transform child in path)
                {

                    if (child.name.ToString().Equals(i.ToString()))
                    {
                        if (child.GetComponentInChildren<Light>().enabled == false)
                        {
                            //Debug.Log(child.name.ToString() + " === " + i.ToString() + " : " + child.name.ToString().Equals(i.ToString()));
                            child.GetComponentInChildren<Light>().enabled = true;
                            yield return new WaitForSeconds(0.5f);
                            child.GetComponentInChildren<Light>().enabled = false;
                            break;
                        }
                    }
                }
            }
        //}
    }
}
