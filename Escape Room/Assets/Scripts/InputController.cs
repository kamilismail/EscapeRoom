using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
        
            if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity))
            {
                DrawerController obj = hit.collider.GetComponent<DrawerController>();
                if (obj)
                {
                    Debug.Log("Click");
                    obj.TriggerInteraction();
                }
            }
        }
    }
}
