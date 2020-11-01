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
    private Color highlightColor;
    
    private String title;
    private String message;

    private Vector2d latlongDelta;
    void Start()
    {
        color = GetComponent<Renderer>();
        defaultColor = color.material.color;
        highlightColor = Color.cyan;

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

    public void SetMessage(String title, String message, Vector2d latlongDelta)
    {
        this.title = title;
        this.message = message;
        this.latlongDelta = latlongDelta;
    }
}
