using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;

public class NewPinMethods : MonoBehaviour
{
    public QuadTreeCameraMovement _QuadTreeCameraMovement;
    public GameObject newPinCanvas;

    public InputField titleName;
    public InputField message;

    private Vector3 pinPos;
    private Vector2d mapLoc;
    public void CreateNewPin(Vector3 pos, Vector2d mapLoc)
    {
        this.mapLoc = mapLoc;
        pinPos = pos;
        newPinCanvas.SetActive(true);
        
    }

    public void CloseNewPin()
    {
        newPinCanvas.SetActive(false);
        RemoveTextField();
    }

    public void PinPost()
    {
        // Instantiate the object back
        String titleStr = titleName.text;
        String messageStr = message.text;
        newPinCanvas.SetActive(false);

        String[] pinInfo = new String[] {titleStr, messageStr};
        
        _QuadTreeCameraMovement.CreatePin(pinInfo,pinPos,mapLoc);
        RemoveTextField();
    }

    private void RemoveTextField()
    {
        titleName.text = "";
        message.text = "";
    }
}
