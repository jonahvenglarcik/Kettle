using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using System.Threading;

public class Node
{
    List<Post> posts;
    LocationInfo location; //TODO: We might have classes that do this
    public Node(LocationInfo loc) 
    {
        posts = new List<Post>();
        location = loc;
    }

    public List<Post> GetPosts() 
    {
        return posts;
    }

    public LocationInfo GetLocation() 
    {
        return location;
    }

    public void addPost(Post post) 
    {
        posts.Add(post);
    }

    public void removePost(Post post)
    {
        posts.Remove(post);
    }


   
}