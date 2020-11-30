using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCanvasActions : MonoBehaviour
{
    public GameObject pin;
    public GameObject pinCanvasDisplay;
    public GameObject newPinCanvas;
    
    private PinPost selectedPinPost;
    private PinCanvasComponents _pinCanvasComponents;
    // Start is called before the first frame update
    void Start()
    {
        _pinCanvasComponents = pinCanvasDisplay.GetComponent<PinCanvasComponents>();
    }

    public void DisplayPinPost(PinPost selectedPinPost)
    {
        this.selectedPinPost = selectedPinPost;
        DisplayMessage();
    }
    private void DisplayMessage()
    {
        pinCanvasDisplay.SetActive(true);
        GameObject[] components = _pinCanvasComponents.getCanvasComponents();
        Text titleText = components[0].GetComponent<Text>();
        Text messageText = components[1].GetComponent<Text>();
        Text usernameText = components[2].GetComponent<Text>();
        Text postTimeText = components[3].GetComponent<Text>();

        String[] message = selectedPinPost.GetMessageInfo();
        titleText.text = message[0];
        messageText.text = message[1];
        usernameText.text = message[2];
        postTimeText.text = message[3];
    }

    public void UpdatePin(PinPost newPin)
    {
        newPin.UpdateObjects(this);
    }
    
    public bool CanOpenPin()
    {
        return !(pinCanvasDisplay.active == true || newPinCanvas.active == true);
    }
}
