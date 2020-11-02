using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Newtonsoft.Json;

public class PostResponse
{
    [JsonProperty("Author")] 
    public UserResponse Author { get; set; }

    [JsonProperty("Title")]
    public string Title { get; set; }

    [JsonProperty("Text")]
    public string Text { get; set; }

    [JsonProperty("TimeStamp")]
    public DateTime TimeStamp { get; set; }

    [JsonProperty("ApprovalRating")]
    public int ApprovalRating { get; set; }

    [JsonProperty("NodeLocation")]
    public LocationResponse NodeLocation { get; set; }
}
