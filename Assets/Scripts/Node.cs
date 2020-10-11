using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;



public class Node
{
    List<Post> posts;
  //  GeoCoordinate location; //TODO: We might have classes that do this
    public Node() 
    {
        //posts = new ArrayList<Post>();
       // location = new GeoCoordinate();
    }

    public List<Post> GetPosts() 
    {
        return posts;
    }

    //public Location GetLocation() 
    //{
    //    return location;
    //}

    public void addPost(Post post) 
    {
        posts.Add(post);
    }


   
}