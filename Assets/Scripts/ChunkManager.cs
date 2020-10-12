using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChunkManager
{
    protected List<Chunk> Chunks;
    protected Location Center;

    protected const int NumChunkNS = 40040;
    protected const int NumChunkEW = 80080;
    protected const float ChunkLoadDist = 1.5f;

    //measured in km
    protected const float EarthHalfCirc = 20020.0f;

    public ChunkManager()
    {
        //Initialize location sensing
        //EnableLocationListening();
        //Center = Input.location.lastData;
        Chunks = new List<Chunk>();
    }

    public override string ToString()
    {
        string res = "";
        res += "Current Location: " + Center.GetLatitude().ToString() + ", " + Center.GetLongitude().ToString() + "\n";
        foreach(Chunk chunk in Chunks)
        {
            res += chunk.ToString() + "\n";
        }
        return res;
    }

    public void MVPTestSuite()
    {
        Location cloc = new Location(20f, 20f);
        Location lu1 = new Location(19.998f, 19.9961f);
        Location lu2 = new Location(19.999f, 19.997f);
        Location lu3 = new Location(20.0002f, 19.9985f);
        User u1 = new User("User One", "user1", lu1);
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
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
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
            if(chunk.GetChunkNumNS() == northSouth && chunk.GetChunkNumEW() == eastWest)
            {
                return true;
            }
        }
        return false;
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


    //gets the north/south index of the chunk containing the point at location
    private static int GetChunkNumNS(Location location)
    {
        return (int)((location.GetLatitude() + 90.0) / 180.0 * NumChunkNS);
    }

    //gets the east/west index of the chunk containing the point at location
    private static int GetChunkNumEW(Location location)
    {
        return (int)((location.GetLongitude() + 180) / 360.0 * NumChunkEW);
    }

    private static float ChunkHeight()
    {
        return EarthHalfCirc / NumChunkNS;
    }

    private static float ChunkWidth(float latitude)
    {
        return (float)(EarthHalfCirc * 2 * Math.Cos(latitude / 180 * Math.PI) / NumChunkEW);
    }

    private static float ChunkLatitude(int chunkIndexNS)
    {
        return ((float)chunkIndexNS / NumChunkNS) * 180f - 90f;
    }

    private static float ChunkLogitude(int chunkIndexEW)
    {
        return ((float)chunkIndexEW / NumChunkEW) * 360f - 180f;
    }
}
