using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Post
{
    private User author;
    private string text;
    private DateTime timeStamp;
    private int approvalRating;

    public Post(User author, string text)
    {
        this.author = author; //TODO user class implementation
        this.text = text;
        timeStamp = DateTime.Now;
        approvalRating = 0;
    }

    public void UpVote() 
    {
        approvalRating++;
    }

    public void DownVote() 
    {
        approvalRating++;
    }

    public User GetAuthor() 
    {
        return author;
    }

    public string GetText() 
    {
        return text;
    }

    public DateTime GetDate() 
    {
        return timeStamp;
    }

    public int GetRating() 
    {
        return approvalRating;
    }

    //TODO: maybe a toString that the server can digest.

    
}
