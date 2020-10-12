using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class for storing Latitude and Longitude
public class Location
{
    protected float Latitude;
    protected float Longitude;

    public Location(float latitude, float longitude)
    {
        this.Latitude = latitude;
        this.Longitude = longitude;
    }

    public float GetLatitude()
    {
        return Latitude;
    }

    public float GetLongitude()
    {
        return Longitude;
    }

    public void SetLongitude(float longitude)
    {
        this.Longitude = longitude;
    }

    public void SetLatitude(float latitude)
    {
        this.Latitude = latitude;
    }
}
