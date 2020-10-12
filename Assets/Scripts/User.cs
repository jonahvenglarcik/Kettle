using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Threading;


/*
 * This class implements User as necessary for Server data and Chunks. This
 * class is not intended to contain specific information relevant to the
 * current user on this device beyond this server information.
 */
public class User
{
    string realName; 
    string userName;

    //Leave this field null unless user is within scope
    Location location;

    //Constructor for users of an unknown or irrelevant location
    public User(string realName, string userName)
    {
        this.realName = realName;
        this.userName = userName;
        this.location = null;
    }

    //Constructor for users of a known relevant location
    public User(string realName, string userName, Location location) 
    {
        this.realName = realName;
        this.userName = userName;
        this.location = location;
    }

    public void SetRealName(string realName)
    {
        this.realName = realName;
    }

    public void SetUserName(string userName)
    {
        this.userName = userName;
    }

    public void SetLocation(Location location)
    {
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

    public Location GetLocation()
    {
        return location;
    }

    public override string ToString()
    {
        string res = "User at " + location.GetLatitude() + ", " + location.GetLongitude() + ":\n";
        res += "Real Name: " + realName + "\n";
        res += "username:  " + userName + "\n";

        return res;
    }
}
