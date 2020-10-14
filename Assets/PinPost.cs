using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinPost : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ClickedPost();
    }

    private void ClickedPost()
    {
        if (Input.GetMouseButtonDown(0))
        {
             RaycastHit hit;
             Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
 
             if (Physics.Raycast(ray, out hit))
             {
                 if (hit.transform.gameObject.layer == 8)
                 {
                     print("Pin is clicked by mouse");
                 }
             }
         }
    }
}
