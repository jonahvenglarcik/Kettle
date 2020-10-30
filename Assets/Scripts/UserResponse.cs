using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;


public class UserResponse
{
    [JsonProperty("RealName")]
    public string RealName { get; set; }

    [JsonProperty("UserName")]
    public string UserName { get; set; }

    [JsonProperty("Location")]
    public LocationResponse Location { get; set; }
}
