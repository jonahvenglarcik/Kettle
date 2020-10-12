﻿using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System;

// DO NOT MODIFY FIELDS IN THIS CLASS, OR FIELDS OUTPUTTED BY THIS CLASS

public class Radius
{
    // Range for distance in km
    // Don't set this larger than 10 EVER
    protected const float Range = .5f;

    // length of a degree of latitude
    protected const float LatLength = 20020f / 180f;

    protected static float LongLength(Location loc)
    {
        return (float)(LatLength * Math.Cos(loc.GetLatitude() * Math.PI / 180f));
    }

    // Device location (loaded continuously from ChunkManager)
    protected Location Center;

    protected List<Node> Nodes;
    protected List<User> Users;

    public Radius(Location center)
    {
        Refresh(center);
    }

    public void Refresh(Location center)
    {
        this.Center = center;
        Nodes = new List<Node>();
        Users = new List<User>();
    }

    public void LoadChunk(Chunk chunk)
    {
        foreach(Node node in chunk.GetNodes())
        {
            if(GetDistance(Center, node.GetLocation()) <= Range)
            {
                this.Nodes.Add(node);
            }
        }

        foreach(User user in chunk.GetPeople())
        {
            if(GetDistance(Center, user.GetLocation()) <= Range)
            {
                this.Users.Add(user);
            }
        }
    }

    // Note - this function uses an approximation for the distance that is
    // highly accurate within 80 degrees of the equator, and across short
    // distances (less than 100 km). (assumes latitude lines are straight)
    // This function calculates the distance between two sets of coordinates
    // to a reasonable approximation.
    private float GetDistance(Location l1, Location l2)
    {
        float nsDist = (l2.GetLatitude() - l1.GetLatitude()) * LatLength;
        float ewDist = (l2.GetLongitude() - l1.GetLongitude()) * 
            LongLength(l1);

        return (float)Math.Pow((Math.Pow(nsDist, 2) + 
            Math.Pow(ewDist, 2)), .5);
    }

    public override string ToString()
    {
        string res = "\tRadius:";
        res += "\tNodes:\n";
        foreach (Node node in Nodes)
        {
            res += node.ToString();
        }
        res += "\tUsers:\n";
        foreach (User user in Users)
        {
            res += user.ToString();
        }

        return res;
    }
}
