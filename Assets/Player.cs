using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Location;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public GameObject TransformLocationProvider;
    private TransformLocationProvider _transformLocationProvider;

    public GameObject _UserProfile;
    // Start is called before the first frame update
    void Start()
    {
        _transformLocationProvider = TransformLocationProvider.GetComponent<TransformLocationProvider>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray;
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.layer);
            if (hit.collider.gameObject.layer == 9 && hit.collider.gameObject == this.gameObject)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    _UserProfile.SetActive(true);             
                }
            }
        }
    }

    private void SetMapChange()
    {
        _transformLocationProvider.ChangeLocation();
    }
}
