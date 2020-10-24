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
    protected Location Location;

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

    //Getters and Setters for fields
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

    //This method is not implemented for Server communication. 
    public override string ToString()
    {
        string res = "";
        res += "Node at " + Location.GetLatitude() + ", " + Location.GetLongitude() + ":\n";
        foreach(Post post in Posts)
        {
            res += post.ToString();
        }
        return res;
    }
}