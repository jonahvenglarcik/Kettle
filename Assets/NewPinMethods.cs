using System;
using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using Mapbox.Utils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
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

    public Sprite OrangeIcon;
    public Sprite GreyIcon;
    
    private Vector3 pinPos;
    private Vector2d mapLoc;

    private bool titleFilled;
    private bool messageFilled;
    public Color orangeColor;
    public Color greyColor;

    public Button PostItButton;
    

    void Start()
    {
        
    }

    void Update()
    {
        CheckTitle();
        CheckPinMessage();
        EnablePost();
    }

    private void EnablePost()
    {
        if (titleFilled && messageFilled)
        {
            PinItImage.color = orangeColor;
            PostItButton.enabled = true;
        }
        else
        {
            PinItImage.color = greyColor;
            PostItButton.enabled = false;
        }
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

    public void CheckTitle()
    {
        if (TitleText.text.Length > 0)
        {
            titleFilled = true;
            PinIcon.sprite = OrangeIcon;
        }
        else
        {
            titleFilled = false;
            PinIcon.sprite = GreyIcon;
        }
    }

    public void CheckPinMessage()
    {
        int pinMessageLength = PinMessage.text.Length;
        if (pinMessageLength > 0)
        {
            messageFilled = true;
            for (int i = 0; i < DottedLines.Length; i++)
            {
                DottedLines[i].color = orangeColor;
            }
        }
        else
        {
            messageFilled = false;
            for (int i = 0; i < DottedLines.Length; i++)
            {
                DottedLines[i].color = greyColor;
            }
        }

        TextSizeTracker.text = pinMessageLength + "/300";
        Debug.Log(TextSizeTracker.text);
    }
}
