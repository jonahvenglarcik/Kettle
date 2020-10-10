using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Device.Location;
using System.Threading;

public class User
{
    string realName; 
    string userName;
    Radius currentRadius;
    List<Chunk> currentChunks;
    GeoCoordinate location;
    List<Post> pinnedPosts;
    Chat chatHistory;

    public User(string realName, string userName, GeoCoordinate location) 
    {
        this.realName = realName;
        this.userName = userName;
        this.location = location;
        currentRadius = null;
        currentChunks = null;
        pinnedPosts = null;
        chatHistory = null;
    }

    public User(string realName, string userName, GeoCoordinate location
        Radius currentRadius, ArrayList<Chunk> currentChunks,
        ArrayList<Post> pinnedPosts, Chat chatHistory)
    {
        this.realName = realName;
        this.userName = userName;
        this.location = location;
        this.currentRadius = currentRadius;
        this.currentChunks = currentChunks;
        this.pinnedPosts = pinnedPosts;
        this.chatHistory = chatHistory;
    }

    public string GetRealName() 
    {
        return realName;
    }

    public string GetUserName()
    {
        return userName;
    }

    public Radius GetRadius() 
    {
        return currentRadius;
    }

    public GeoCoordinate GetLocation()
    {
        return location;
    }

}
