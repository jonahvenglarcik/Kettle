using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.Win32;

public class Chunk
{
    // coordinates of this chunk in units of chunks
    protected int ChunkNumNS;
    protected int ChunkNumEW;
    protected List<Node> Nodes;
    protected List<User> People;


    public Chunk(int chunkNumNS, int chunkNumEW)
    {
        ChunkNumNS = chunkNumNS;
        ChunkNumEW = chunkNumEW;
        Nodes = new List<Node>();
        People = new List<User>();
    }

    public Chunk(int chunkNumNS, int chunkNumEW, List<Node> nodes, List<User> people)
    {
        ChunkNumNS = chunkNumNS;
        ChunkNumEW = chunkNumEW;
        Nodes = nodes;
        People = people;
    }

    public int GetChunkNumNS()
    {
        return ChunkNumNS;
    }

    public int GetChunkNumEW()
    {
        return ChunkNumEW;
    }

    public void AddUser(User user)
    {
        People.Add(user);
    }

    public void RemoveUser(string userName)
    {
        //bool userFound = false;
        for(int n = 0; n < People.Count; n++)
        {
            if(People[n].GetUserName() == userName)
            {
                People.Remove(People[n]);
                break;
            }
        }
    }

    public List<User> GetPeople()
    {
        return People;
    }

    public void AddNode(Node node)
    {
        Nodes.Add(node);
    }

    public void removeNode(Node node)
    {
        Nodes.Remove(node);
    }

    public List<Node> GetNodes()
    {
        return Nodes;
    }

    public override string ToString()
    {
        string res = "\tChunk At " + ChunkNumNS + ", " + ChunkNumEW + "\n";
        res += "\tNodes:\n";
        foreach(Node node in Nodes)
        {
            res += node.ToString();
        }
        res += "\tUsers:\n";
        foreach(User user in People)
        {
            res += user.ToString();
        }

        return res;
    }
}
