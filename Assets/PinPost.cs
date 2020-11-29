using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Utils;
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
    public Color highlightColor;
    
    private String title;
    private String message;
    private String username;

    private Vector2d latlongDelta;
    void Start()
    {
        color = GetComponent<Renderer>();
        defaultColor = color.material.color;

        //title = "";
        //message = "";
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
            if (hit.collider.gameObject.layer == 8 && hit.collider.gameObject == this.gameObject)
            {
                color.material.SetColor("_Color",highlightColor);
                if (Input.GetMouseButtonDown(0) && _pinCanvasActions.CanOpenPin())
                {
                    _pinCanvasActions.DisplayPinPost(this);
                }
            }
            else
            {
                color.material.SetColor("_Color",defaultColor);
            }
        }
    }

    public String[] GetMessageInfo()
    {
        return new [] {title, message, username};
    }

    public void UpdateObjects(PinCanvasActions pinCanvasActionsRef)
    {
        _pinCanvasActions = pinCanvasActionsRef;
    }

    public void SetMessage(String title, String message, Vector2d latlongDelta)
    {
        this.title = title;
        this.message = message;
        this.latlongDelta = latlongDelta;
    }
    
    public void SetMessage(String title, String message, String username, Vector2d latlongDelta)
    {
        this.title = title;
        this.message = message;
        this.username = username;
        this.latlongDelta = latlongDelta;
    }
}
