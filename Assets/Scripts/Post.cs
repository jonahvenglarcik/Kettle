using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This class contains Post information as relevant to storage in Chunks and
 * communication with server, and getters and setters for this information.
 */
public class Post
{
    private User author;
    private string text;
    private DateTime timeStamp;
    private int approvalRating;

    //Constructor for a post just created by the user
    public Post(User author, string text)
    {
        this.author = author;
        this.text = text;
        timeStamp = DateTime.Now;
        approvalRating = 0;
    }

    //Constructor for a post downloaded from the server
    public Post(User author, string text, DateTime timestamp, int approval)
    {
        this.author = author;
        this.text = text;
        this.timeStamp = timestamp
        this.approvalRating = approval;
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

    public override string ToString()
    {
        string res = "Post:\n";
        res += "Author:    " + author.GetUserName() + "\n";
        res += "Timestamp: " + timeStamp.ToString() + "\n";
        res += "Approval:  " + approvalRating.ToString() + "\n";
        res += "Text:      " + text + "\n";

        return res;
    }


}
