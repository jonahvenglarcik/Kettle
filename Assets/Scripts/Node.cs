using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Threading;


/*
 * Implementation of Nodes to be stored in Chunks and Radius, and for
 * communication with server.
 */
public class Node
{
    protected List<Post> Posts;
    Location Location;

    //Constructor for new empty node
    public Node(Location loc) 
    {
        Posts = new List<Post>();
        Location = loc;
    }

    //Constructor for node containing a set of posts
    public Node(Location loc, List<Post> posts)
    {
        Posts = posts;
        Location = loc;
    }

    public List<Post> GetPosts() 
    {
        return Posts;
    }

    public Location GetLocation() 
    {
        return Location;
    }

    public void addPost(Post post) 
    {
        Posts.Add(post);
    }

    public void removePost(Post post)
    {
        Posts.Remove(post);
    }


   public override string ToString()
    {
        string res = "";
        res += "Node at " + location.GetLatitude() + ", " + location.GetLongitude() + ":\n";
        foreach(Post post in Posts)
        {
            res += post.ToString();
        }
        return res;
    }
}