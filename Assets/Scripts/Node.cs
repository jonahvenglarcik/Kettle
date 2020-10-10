using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Device.Location;


public class Node
{
    List<Post> posts;
    GeoCoordinate location; //TODO: We might have classes that do this
    public Node() 
    {
        posts = new ArrayList<Post>();
        location = new GeoCoordinate();
    }

    public ArrayList<Post> GetPosts() 
    {
        return posts;
    }

    public Location GetLocation() 
    {
        return location;
    }

    public void addPost(Post post) 
    {
        posts.Add(post);
    }


   
}