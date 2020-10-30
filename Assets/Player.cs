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

    private void MovePerson()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = new Vector3(transform.position.x + 2.5f * Time.deltaTime, transform.position.y,
                transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x + 2.5f* Time.deltaTime * -1, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(0,0,0);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(0,0,0);
        }
    }

    private void SetMapChange()
    {
        _transformLocationProvider.ChangeLocation();
        //var map = LocationProviderFactory.Instance.mapManager;
        //map.ResetMap();
    }
}
