using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Threading;

public class User
{
    int userID;
    string realName; 
    string userName;
    LocationInfo location;

    public User(string realName, string userName, LocationInfo location) 
    {
        this.realName = realName;
        this.userName = userName;
        this.location = location;
    }

    public string GetRealName() 
    {
        return realName;
    }

    public string GetUserName()
    {
        return userName;
    }

    public LocationInfo GetLocation()
    {
        return location;
    }

}
