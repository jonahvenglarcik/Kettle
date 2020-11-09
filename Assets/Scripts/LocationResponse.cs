using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
public class LocationResponse
{
    [JsonProperty("Latitude")]
    public float Latitude { get; set; }

    [JsonProperty("Longitude")]
    public float Longitude { get; set; }
}

