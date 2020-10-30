using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class LocationResponse
{
    [JsonProperty("latitude")]
    public float Latitude { get; set; }

    [JsonProperty("longitude")]
    public float Longitude { get; set; }
}

