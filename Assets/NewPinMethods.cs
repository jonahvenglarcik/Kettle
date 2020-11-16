using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class NewPinMethods : MonoBehaviour
{
    public QuadTreeCameraMovement _QuadTreeCameraMovement;
    public GameObject newPinCanvas;

    public InputField titleName;
    public InputField message;

    public Text TitleText;
    public Image PinIcon;
    public Text PinMessage;
    public Image[] DottedLines;
    public Text TextSizeTracker;
    public Image PinItImage;
    
    private Vector3 pinPos;
    private Vector2d mapLoc;

    public Color orangeColor;

    private SpriteRenderer PinItImageColor;
    void Update()
    {
        orangeColor = new Color(255,173,0);
        CheckMessage();
        CheckPinMessage();
        PinItImage.color = orangeColor;
    }
    
    public void CreateNewPin(Vector3 pos, Vector2d mapLoc)
    {
        //PinItImage.sprite
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

    public void CheckMessage()
    {
        
    }

    public void CheckPinMessage()
    {
        int pinMessageLength = PinMessage.text.Length;
        TextSizeTracker.text = pinMessageLength + "/300";
        Debug.Log(TextSizeTracker.text);
    }
}
