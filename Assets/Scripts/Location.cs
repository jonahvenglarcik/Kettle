using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location
{
    protected float latitude;
    protected float longitude;

    public Location(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }

    public float GetLatitude()
    {
        return latitude;
    }

    public float GetLongitude()
    {
        return longitude;
    }

    public void SetLongitude(float longitude)
    {
        this.longitude = longitude;
    }

    public void SetLatitude(float latitude)
    {
        this.latitude = latitude;
    }
}
