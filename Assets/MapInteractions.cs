﻿using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using UnityEngine;

public class MapInteractions : MonoBehaviour
{
    public GameObject pin;
    private bool onMap;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onMap)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(pin, Input.mousePosition, Quaternion.identity);
            }
        }
    }

    private void PinLocation()
    {
        var map = LocationProviderFactory.Instance.mapManager;
    }

    void OnMouseEnter()
    {
        onMap = true;
    }

    void OnMouseExit()
    {
        onMap = false;
    }
}
