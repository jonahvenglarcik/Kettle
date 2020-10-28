using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32;
using UnityEngine;
using UnityEngine.UI;

public class PinPost : MonoBehaviour
{
    // ------Will Be Updated Later --------
    private GameObject User;
    // ------End of Objects to be updated ----
    
    private PinCanvasActions _pinCanvasActions;
    private Renderer color;
    private Color defaultColor;
    private Color highlightColor;
    
    private String title;
    private String message;
    void Start()
    {
        color = GetComponent<Renderer>();
        defaultColor = color.material.color;
        highlightColor = Color.cyan;

        title = "A Day In The Park";
        message = "Hello everyone. Beware a freaking dog is roaming here biting every single person! Even me included.";
        
    }

    // Update is called once per frame
    void Update()
    {
        ClickedPost();
    }

    private void ClickedPost()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                color.material.SetColor("_Color",highlightColor);
            }
            else
            {
                color.material.SetColor("_Color",defaultColor);
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Enable Message");
                _pinCanvasActions.DisplayPinPost(this);
            }
        }
    }

    public String[] GetMessageInfo()
    {
        return new [] {title, message};
    }

    public void UpdateObjects(PinCanvasActions pinCanvasActionsRef)
    {
        _pinCanvasActions = pinCanvasActionsRef;
    }
}
