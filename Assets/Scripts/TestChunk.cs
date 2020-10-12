using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class TestChunk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ChunkManager manager = new ChunkManager();
        manager.UpdateCenter(new Location(20.0f, 20.0f));
        UnityEngine.Debug.Log(manager.ToString());
    }
}
