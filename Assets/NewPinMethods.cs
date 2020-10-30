using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPinMethods : MonoBehaviour
{
    public GameObject newPinCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateNewPin()
    {
        //_PinCanvasActions.UpdatePin(newPin.GetComponent<PinPost>());
        newPinCanvas.SetActive(true);
    }

    public void CloseNewPin()
    {
        newPinCanvas.SetActive(false);
    }

    public void PinPost()
    {
        // Instantiate the object back
        newPinCanvas.SetActive(false);
    }
}
