﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Microsoft.Win32;

// ChunkManager manages chunks, and calls necessary functions in Radius object
// to keep it updated. From outside ChunkManager, the only necessary actions to
// ensure that it works are creating it upon start, and calling the
// UpdateCenter method every few frames
public class ChunkManager
{
    protected List<Chunk> Chunks;

    // should be the coordinates of the device
    protected Location Center;

    // number of chunks you will pass through on a straight line from south to
    // north poles
    protected const int NumChunkNS = 40040;

    // number of chunks you will pass through on a straight line
    // circumnavigation
    protected const int NumChunkEW = 80080;

    // All chunks within this distance of the center chunk will be loaded
    // (rectangular)
    protected const float ChunkLoadDist = 1.5f;

    // measured in km, half circumference of the Earth
    protected const float EarthHalfCirc = 20020.0f;

    // Standard constructor for ChunkManager
    public ChunkManager()
    {
        // Initialize location sensing:
        //EnableLocationListening();
        //Center = Input.location.lastData;
        Chunks = new List<Chunk>();
    }

    public override string ToString()
    {
        string res = "";
        res += "Current Location: " + Center.GetLatitude().ToString() + ", " +
            Center.GetLongitude().ToString() + "\n";
        foreach(Chunk chunk in Chunks)
        {
            res += chunk.ToString() + "\n";
        }
        return res;
    }

    // Delete this function outside of testing branches
    public void MVPTestSuite()
    {
        Location cloc = new Location(20f, 20f);

        // Center Chunk Users
        Location lu1 = new Location(19.998f, 19.9961f);
        Location lu2 = new Location(19.999f, 19.997f);
        Location lu3 = new Location(20.0002f, 19.9985f);
        User u1 = new User("User One", "user1", lu1);
        User u2 = new User("User Two", "user2", lu2);
        User u3 = new User("User Three", "user3", lu3);

        // Add users to chunk
        Chunk chunk1 = ChunkFromIndex(GetChunkNumNS(cloc), GetChunkNumEW(cloc));
        if(chunk1 == null)
        {
            UnityEngine.Debug.Log("null value found for chunk1");
        }
        else
        {
            chunk1.AddUser(u1);
            chunk1.AddUser(u2);
            chunk1.AddUser(u3);
        }

        // Far right center chunk Users
        Location lu4 = new Location(19.9965f, 20.016f);
        Location lu5 = new Location(19.9985f, 20.0152f);

        User u4 = new User("User Four", "user4", lu4);
        User u5 = new User("User Five", "user5", lu5);
        Chunk chunkr = ChunkFromIndex(GetChunkNumNS(lu4), GetChunkNumEW(lu4));
        if(chunkr == null)
        {
            UnityEngine.Debug.Log("null value found for chunkr");
        }
        else
        {
            chunkr.AddUser(u4);
            chunkr.AddUser(u5);
        }
        // Top center chunk Users
        Location lu6 = new Location(20.010f, 20f);
        User u6 = new User("User Six", "user6", lu6);

        Chunk chunkt = ChunkFromIndex(GetChunkNumNS(lu6), GetChunkNumEW(lu6));
        if(chunkt == null)
        {
            UnityEngine.Debug.Log("null value found for chunkt");
        }
        else
        {
            chunkt.AddUser(u6);
        }
        // Posts
        DateTime dt1 = DateTime.Now;
        DateTime dt2 = new DateTime(2020, 10, 10, 10, 22, 35);
        DateTime dt3 = new DateTime(2020, 9, 24, 15, 56, 20);

        Post p1 = new Post(u1, "user1 wuz here", dt2, 1);
        Post p2 = new Post(u2, "user2 wuz here", dt3, 5);
        Post p3 = new Post(u3, "user3 wuz here", dt1, 1);
        // Nodes
        List<Post> lst1 = new List<Post> { p3, p2, p1 };
        List<Post> lst2 = new List<Post> { p3, p1 };

        Location ln1 = new Location(19.997f, 19.9999f);
        Location ln2 = new Location(19.9975f, 19.997f);

        Node n1 = new Node(ln1, lst1);
        Node n2 = new Node(ln2);
        if (chunk1 == null)
        {
            //UnityEngine.Debug.Log("null value found for chunk1");
        }
        else
        {
            chunk1.AddNode(n1);
            chunk1.AddNode(n2);
        }
        //Far right chunk
        Location ln3 = new Location(20f, 20.015f);
        Node n3 = new Node(ln3, lst2);

        if(chunkr != null)
        {
            chunkr.AddNode(n3);
        }
    }

    private IEnumerator EnableLocationListening()
    {
        // First, check if user has location service enabled
        if (!Input.location.isEnabledByUser)
            yield break;

        // Start service before querying location
        Input.location.Start();

        // Wait until service initializes
        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing &&
            maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            //Throw some error here
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            //Throw some error here
            yield break;
        }
    }

    //Updates the user's location
    //This method must be called for each liaison with server
    public void UpdateCenter(Location location)
    {
        //Assertion statement for Location listening status

        //Center = Input.location.lastData;
        Center = location;
        UpdateChunks();
    }

    //Grab all necesssary chunks, remove any unnecessary chunks
    private void UpdateChunks()
    {
        int centerChunkNS = GetChunkNumNS(Center);
        int centerChunkEW = GetChunkNumEW(Center);

        // Bounds on north/south chunks
        int minChunkNS = (int)Math.Max(0, centerChunkNS -
            Math.Ceiling(ChunkLoadDist / ChunkHeight()));
        int maxChunkNS = (int)Math.Min(NumChunkNS, centerChunkNS +
            Math.Ceiling(ChunkLoadDist / ChunkHeight()));

        // Bounds on East/West chunks (within a couple kilometers of 180d west,
        // one of these numbers may be negative. This is intended behavior,
        // Wrapping is handled in GrabChunkFromServer method).
        int minChunkEW = (int)(centerChunkEW -
            Math.Ceiling(ChunkLoadDist / ChunkWidth(Center.GetLatitude())));
        int maxChunkEW = (int)(centerChunkEW +
            Math.Ceiling(ChunkLoadDist / ChunkWidth(Center.GetLatitude())));

        //Chunks = new ArrayList<Chunk>
        int n;
        for(n = 0; n < Chunks.Count; n++)
        {
            if (Chunks[n].GetChunkNumNS() > maxChunkNS ||
                Chunks[n].GetChunkNumNS() < minChunkNS ||
                Chunks[n].GetChunkNumEW() > maxChunkEW ||
                Chunks[n].GetChunkNumEW() < minChunkEW)
            {
                Chunks.Remove(Chunks[n]);
                n--;
            }
        }

        for(int x = minChunkEW; x <= maxChunkEW; x++)
        {
            for(int y = minChunkNS; y <= maxChunkNS; y++)
            {
                if(ChunksContains(y, x))
                {
                    UpdateChunk(y, x);
                }
                else
                {
                    Chunks.Add(GrabChunkFromServer(y, x));
                }
            }
        }
    }

    private bool ChunksContains(int northSouth, int eastWest)
    {
        foreach(Chunk chunk in Chunks)
        {
            if(chunk.GetChunkNumNS() == northSouth && chunk.GetChunkNumEW() ==
                eastWest)
            {
                return true;
            }
        }
        return false;
    }

    // ChunkFromIndex takes chunk indexes, and finds the chunk at that index
    // if there is one in the current scope
    private Chunk ChunkFromIndex(int northSouth, int eastWest)
    {
        foreach(Chunk chunk in Chunks)
        {
            if(chunk.GetChunkNumNS() == northSouth && chunk.GetChunkNumEW() ==
                eastWest)
            {
                return chunk;
            }
        }
        return null;
    }

    private Chunk GrabChunkFromServer(int northSouth, int eastWest)
    {
        //TODO: manage server communication in later versions

        //Default: If no chunk yet exists at location, make a new empty one
        //Always use Default behavior for MVP
        return new Chunk(northSouth, eastWest);
    }

    private void UpdateChunk(int northSouth, int eastWest)
    {
        //TODO: manage server communication in later versions
    }



    // gets the north/south index of the chunk containing the point at location
    private static int GetChunkNumNS(Location location)
    {
        return (int)((location.GetLatitude() + 90.0) / 180.0 * NumChunkNS);
    }

    // gets the east/west index of the chunk containing the point at location
    private static int GetChunkNumEW(Location location)
    {
        return (int)((location.GetLongitude() + 180) / 360.0 * NumChunkEW);
    }

    // finds the height of each chunk in km
    private static float ChunkHeight()
    {
        return EarthHalfCirc / NumChunkNS;
    }

    // finds the width of each chunk in km at latitude
    private static float ChunkWidth(float latitude)
    {
        return (float)(EarthHalfCirc * 2 * Math.Cos(latitude / 180 * Math.PI)
            / NumChunkEW);
    }

    // Finds the latitude of the southwest corner of a chunk of a given
    // North/South index
    private static float ChunkLatitude(int chunkIndexNS)
    {
        return ((float)chunkIndexNS / NumChunkNS) * 180f - 90f;
    }

    // Finds the longitude of the southwest corner of a chunk of a given
    // East/West index
    private static float ChunkLogitude(int chunkIndexEW)
    {
        return ((float)chunkIndexEW / NumChunkEW) * 360f - 180f;
    }
}
