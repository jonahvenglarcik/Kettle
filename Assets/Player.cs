using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject TransformLocationProvider;
    private TransformLocationProvider _transformLocationProvider;
    private 
    // Start is called before the first frame update
    void Start()
    {
        _transformLocationProvider = TransformLocationProvider.GetComponent<TransformLocationProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        //MovePerson();
        if (Input.GetMouseButtonUp(1))
        {
            //SetMapChange();
        }
    }

    private void SetMapChange()
    {
        _transformLocationProvider.ChangeLocation();
    }
}
