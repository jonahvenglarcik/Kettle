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
    string RealName; 
    string UserName;

    //Leave this field null unless user is within scope
    Location Location;

    //Constructor for users of an unknown or irrelevant location
    public User(string realName, string userName)
    {
        this.RealName = realName;
        this.UserName = userName;
        this.Location = null;
    }

    //Constructor for users of a known relevant location
    public User(string realName, string userName, Location location) 
    {
        this.RealName = realName;
        this.UserName = userName;
        this.Location = location;
    }

    public void SetRealName(string realName)
    {
        this.RealName = realName;
    }

    public void SetUserName(string userName)
    {
        this.UserName = userName;
    }

    public void SetLocation(Location location)
    {
        this.Location = location;
    }

    public string GetRealName() 
    {
        return RealName;
    }

    public string GetUserName()
    {
        return UserName;
    }

    public Location GetLocation()
    {
        return Location;
    }

    public override string ToString()
    {
        string res = "User at " + Location.GetLatitude() + ", " + Location.GetLongitude() + ":\n";
        res += "Real Name: " + RealName + "\n";
        res += "username:  " + UserName + "\n";

        return res;
    }
}
