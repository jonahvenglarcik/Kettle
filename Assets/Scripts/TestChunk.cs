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
        manager.MVPTestSuite();
        UnityEngine.Debug.Log(manager.ToString());
        manager.UpdateCenter(new Location(20.0f, 19.995f));
        UnityEngine.Debug.Log(manager.ToString());
        manager.UpdateCenter(new Location(20.0f, 20.0f));
        UnityEngine.Debug.Log(manager.ToString());
        manager.UpdateCenter(new Location(19.995f, 20.0f));
        UnityEngine.Debug.Log(manager.ToString());
        manager.UpdateCenter(new Location(20.0f, 20.0f));
        UnityEngine.Debug.Log(manager.ToString());
    }
}
