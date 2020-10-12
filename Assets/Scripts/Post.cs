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
    private User Author;
    private string Text;
    private DateTime TimeStamp;
    private int ApprovalRating;

    //Constructor for a post just created by the user
    public Post(User author, string text)
    {
        this.Author = author;
        this.Text = text;
        TimeStamp = DateTime.Now;
        ApprovalRating = 1;
    }

    //Constructor for a post downloaded from the server
    public Post(User author, string text, DateTime timestamp, int approval)
    {
        this.Author = author;
        this.Text = text;
        this.TimeStamp = timestamp;
        this.ApprovalRating = approval;
    }

    // Getters and Setters
    public void SetApprovalRating(int approval)
    {
        this.ApprovalRating = approval;
    }

    public User GetAuthor() 
    {
        return Author;
    }

    public string GetText() 
    {
        return Text;
    }

    public DateTime GetDate() 
    {
        return TimeStamp;
    }

    public int GetRating() 
    {
        return ApprovalRating;
    }

    //Not yet implemented for server commmunications
    public override string ToString()
    {
        string res = "Post:\n";
        res += "Author:    " + Author.GetUserName() + "\n";
        res += "Timestamp: " + TimeStamp.ToString() + "\n";
        res += "Approval:  " + ApprovalRating.ToString() + "\n";
        res += "Text:      " + Text + "\n";

        return res;
    }


}
