using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltLocationInfo : MonoBehaviour
{
    public float latitude;
    public float longitude;

    public AltLocationInfo(float latitude, float longitude)
    {
        this.latitude = latitude;
        this.longitude = longitude;
    }
}
