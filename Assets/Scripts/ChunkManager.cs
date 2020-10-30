using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// ChunkManager manages chunks, and calls necessary functions in Radius object
// to keep it updated. From outside ChunkManager, the only necessary actions to
// ensure that it works are creating it upon start, and calling the
// UpdateCenter method every few frames
public class ChunkManager : MonoBehaviour
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

    protected Radius Radius;

    //Stores the last time that information was updated from server
    protected DateTime lastUpdate;

    // This Constructor uses (Hours, Minutes, Seconds)
    protected TimeSpan UpdateSpan = new TimeSpan(0, 0, 1);
    // Can also use a constructor with params 
    // (Days, Hours, Minutes, Seconds, Milliseconds)

    void Start()
    {
        this.Radius = new Radius();
        // Initialize location sensing:
        EnableLocationListening();


        //Create chunks list
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
    void Update()
    {
        //Assertion statement for Location listening status


        DateTime currTime = DateTime.UtcNow;
        if (currTime > lastUpdate + UpdateSpan)
        {
            // Run update code here

            //Set Center
            LocationInfo temp = Input.location.lastData;
            Center = new Location(temp.latitude, temp.longitude);
            UpdateChunks();

            Radius.Refresh(Center);
            foreach (Chunk chunk in Chunks)
            {
                Radius.LoadChunk(chunk);
            }
            // Keep this line
            lastUpdate = currTime;
        }
        //Check how long since last location update
        //Maybe change this system to be more specifically based on time


    }

    public Radius GetRadius()
    {
        return this.Radius;
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
